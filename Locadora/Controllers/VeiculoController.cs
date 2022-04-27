using Locadora.Data;
using Locadora.Models;
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
    public class VeiculoController : Controller
    {
        private readonly MainContext _db;      
        private readonly IHostingEnvironment _hostingEnvironment;
    
        public VeiculoController(MainContext context, IHostingEnvironment hostingEnvironment)
        {
            _db = context;
            _hostingEnvironment = hostingEnvironment;
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
            _db.Veiculos.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
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

        [HttpPost]
        public ActionResult SalvarFoto(FotoDeGaragem model, IFormFile arquivoBinario)
        {
            try
            {
                if (arquivoBinario == null) throw new Exception("Por favor anexe o arquivo!");
                
                model.Descricao = arquivoBinario.FileName;
                model = AnexarDocumento(model, arquivoBinario);

                if (model.ArquivoId == 0)
                {
                    _db.Arquivos.Add(model);
                }
                else
                {
                    var novo = _db.Arquivos.Find(model.ArquivoId);
                    novo.AtualizarDocumento(model);
                    _db.Entry(novo).State = EntityState.Modified;
                }

                var tiposArquivosObrigatorios = _db.TiposArquivos.Where(x => x.Obrigatorio && x.TiposBeneficios.Any(y => y.Casos.Any(z => z.CasoId == model.CasoId)) && x.Ativo);

                var arquivosAnexadosObrigatorios = _db.Arquivos.Where(x => x.CasoId == model.CasoId && x.TipoArquivo.Obrigatorio);

                var tipoDeArquivoAnexado = _db.TiposArquivos.Find(model.TipoArquivoId);

                var quantidadeTiposArquivos = tiposArquivosObrigatorios.Count();

                var quantidadeArquivosAnexados = arquivosAnexadosObrigatorios.Count() + (tipoDeArquivoAnexado.Obrigatorio ? 1 : 0);

                if (quantidadeTiposArquivos == quantidadeArquivosAnexados)
                {
                    var encontrarTarefa = _db.Tarefas.FirstOrDefault(x => x.TipoTarefa == TipoTarefa.EntregaDocumentacao && x.CasoId == model.CasoId);
                    if (encontrarTarefa != null && !encontrarTarefa.Finalizada)
                    {
                        encontrarTarefa.Solucao = "Tarefa atendida com o anexo de toda a documentação do caso";
                        encontrarTarefa.DataFinalizacao = DateTime.Now;
                        encontrarTarefa.FuncionarioResponsavelId = Funcionario.FuncionarioLogado().FuncionarioId;
                        encontrarTarefa.Finalizada = true;
                    }
                }

                _db.SaveChanges();
                return Json(new { Success = "Documento anexado com sucesso!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Error = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private FotoDeGaragem AnexarDocumento(FotoDeGaragem model, IFormFile arquivoBinario)
        {
            int ByteSize = 1048576;
            int SizeInBytesMax = ByteSize * 10;
            var virtualPath = "~/Uploads/Fotos";
            var allowedExtensions = new List<string> { ".png", ".jpg", ".jpeg", ".gif" };
            var arquivo = new FotoDeGaragem();
            if (model.Id != 0) arquivo = _db.FotosDeGaragem.Find(model.Id);
            if (arquivoBinario != null && arquivoBinario.Length > 0)
            {
                string extension = Path.GetExtension(arquivoBinario.FileName);
                if (!allowedExtensions.Contains(extension.ToLower())) throw new Exception("Extensão não permitida");
                
                //var physicalPath = Server.MapPath(virtualPath);
                var physicalPath = Server.MapPath(virtualPath);
                
                if (!Directory.Exists(physicalPath)) Directory.CreateDirectory(physicalPath);
                if (!Directory.Exists(physicalPath)) throw new Exception($"Diretório {physicalPath} não existe!");
                string fileName = $"{Guid.NewGuid()}{extension}";
                string filePath = Path.Combine(physicalPath, fileName);
                if (model.ArquivoId != 0)
                {
                    var fileOld = Server.MapPath(arquivo.Caminho);
                    if (System.IO.File.Exists(fileOld)) System.IO.File.Delete(fileOld);
                }
                arquivoBinario.SaveAs(filePath);
                model.Caminho = $"{virtualPath}/{fileName}";
            }
            else if (model.ArquivoId != 0)
            {
                var fileOld = Server.MapPath(arquivo.Caminho);
                if (System.IO.File.Exists(fileOld)) System.IO.File.Delete(fileOld);
                model.Caminho = string.Empty;
            }
            return model;
        }
    }
}