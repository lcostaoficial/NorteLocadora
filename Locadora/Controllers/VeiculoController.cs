using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Locadora.Controllers
{
    [Authorize]
    public class VeiculoController : Controller
    {
        private readonly MainContext _db;
        private IWebHostEnvironment _hostEnvironment;

        public VeiculoController(MainContext context, IWebHostEnvironment hostEnvironment)
        {
            _db = context;
            _hostEnvironment = hostEnvironment;
        }

        public ActionResult Index()
        {
            var list = _db.Veiculos.Where(x => x.Ativo).ToList();
            return View(list);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Veiculo model)
        {
            if (!ModelState.IsValid) throw new Exception();
            var entity = _db.Veiculos.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Editar", new { id = entity.Entity.Id });
        }

        public ActionResult Editar(int id)
        {
            var model = _db.Veiculos.Include(x => x.FotosDeGaragem).FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        public ActionResult Remover(int id)
        {
            var veiculo = _db.Veiculos.Find(id);
            veiculo.Excluir();
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Veiculo model)
        {
            if (!ModelState.IsValid) throw new Exception();
            var novo = _db.Veiculos.Find(model.Id);
            novo.Atualizar(model);
            _db.Entry(novo).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ExcluirFoto(int id)
        {
            var foto = _db.FotosDeGaragem.Find(id);
            foto.Inativar();
            _db.SaveChanges();

            var existePrincipal = _db.FotosDeGaragem.Any(x => x.Principal && x.VeiculoId == foto.VeiculoId && x.Ativo);

            if (!existePrincipal)
            {
                var novaFotoPrincipal = _db.FotosDeGaragem.OrderByDescending(x => x.DataDeRegistro).FirstOrDefault();

                if (novaFotoPrincipal != null)
                    novaFotoPrincipal.Principal = true;

                _db.SaveChanges();
            }

            return RedirectToAction("Editar", new { id = foto.VeiculoId });
        }

        [HttpPost]
        public ActionResult SalvarFoto(FotoDeGaragem model, IFormFile arquivoBinario)
        {
            if (!ModelState.IsValid) throw new Exception();
            if (arquivoBinario == null) throw new Exception("Por favor anexe o arquivo!");
            model = AnexarDocumento(model, arquivoBinario);
            model.DataDeRegistro = DateTime.Now;
            model.Ativo = true;

            if (model.Principal == true)
            {
                var fotosExistentes = _db.FotosDeGaragem.Where(x => x.Principal && x.VeiculoId == model.VeiculoId && x.Ativo);

                foreach (var item in fotosExistentes)
                {
                    item.TornarFotoNaoPrincipal();
                }
            }
            else
            {
                var existePrincipal = _db.FotosDeGaragem.Any(x => x.Principal && x.VeiculoId == model.VeiculoId && x.Ativo);

                if (!existePrincipal)
                    model.Principal = true;
            }

            _db.FotosDeGaragem.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Editar", new { id = model.VeiculoId });
        }

        private FotoDeGaragem AnexarDocumento(FotoDeGaragem model, IFormFile arquivoBinario)
        {
            var allowedExtensions = new List<string> { ".png", ".jpg", ".jpeg", ".gif" };

            var physicalPath = $"{_hostEnvironment.WebRootPath}\\Uploads\\Fotos";

            if (arquivoBinario != null && arquivoBinario.Length > 0)
            {
                string extension = Path.GetExtension(arquivoBinario.FileName);

                if (!allowedExtensions.Contains(extension.ToLower()))
                    throw new Exception("Extensão não permitida");

                if (!Directory.Exists(physicalPath))
                    Directory.CreateDirectory(physicalPath);

                if (!Directory.Exists(physicalPath))
                    throw new Exception($"Diretório {physicalPath} não existe!");

                string fileName = $"{Guid.NewGuid()}{extension}";

                string filePath = Path.Combine(physicalPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    arquivoBinario.CopyTo(stream);
                }

                model.Caminho = $"{fileName}";
            }
            else
            {
                throw new Exception("Foto não anexada");
            }

            return model;
        }
    }
}