using Locadora.Data;
using Locadora.Helpers;
using Locadora.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace Locadora.Controllers
{
    [Authorize]
    public class ClienteController : BaseController
    {
        private readonly MainContext _db;
        private IWebHostEnvironment _hostEnvironment;

        public ClienteController(MainContext context, IWebHostEnvironment hostEnvironment)
        {
            _db = context;
            _hostEnvironment = hostEnvironment;
        }

        public ActionResult Index()
        {
            var list = _db.Clientes.ToList();
            return View(list);
        }

        public ActionResult Novo(bool? mock = false)
        {
            if (mock == true)
            {
                var teste = new Cliente()
                {
                    Cpf = CpfUtils.GerarCpf(),
                    Nome = "José Lucas da Silva Costa",
                    NomeMae = "Maria Aparecida da Silva",
                    ClienteEstrangeiro = false,
                    DataNascimento = DateTime.Now,
                    Cep = "76811468",
                    Rua = "Reco Reco",
                    Numero = "1813",
                    Bairro = "Castanheira",
                    Estado = Estado.RO,
                    Cidade = "Porto Velho",
                    Cnh = "123",
                    DataDeVencimentoDaCnh = DateTime.Now,
                    EstadoCivil = EstadoCivil.Casado,
                    Naturalidade = "Porto Velho",
                    Nacionalidade = "Brasileira",
                    Rg = "1250783",
                    OrgaoExpedidorRg = OrgaoExpedidorRg.SSP,
                    EstadoOrgaoExpedidor = Estado.RO,
                    TelefoneMovel = "(69) 99219-9171",
                    Email = "lucascosta2013@live.com",
                    Profissao = "Analista de Sistemas"
                };

                return View(teste);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Cliente model)
        {
            try
            {                
                ProcessarImagemBase64String(model.ImageBase64String, model.Cpf);

                ValidarEstrangeiro(model);

                if (model.CatCnh == null || !model.CatCnh.Any())
                    throw new Exception("Categoria da CNH não preenchida!");

                if (!ModelState.IsValid) throw new Exception("Campos inválidos!");

                if (!model.ValidarCpf()) throw new Exception("O CPF informado é inválido!");

                var cpfJaExiste = _db.Clientes.Any(x => x.Cpf == model.Cpf);
                if (cpfJaExiste) throw new Exception("O CPF informado já foi utilizado!");
                model.ProcessarCategoriaDaCnh();
                _db.Clientes.Add(model);
                model.Ativo = true;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Message(e.Message, MessageType.error);
                return View(model);
            }
        }

        public ActionResult Editar(int id)
        {
            var model = _db.Clientes.Find(id);
            model.CarrregarCategoriaDaCnh();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cliente model)
        {
            try
            {
                ProcessarImagemBase64String(model.ImageBase64String, model.Cpf);

                ValidarEstrangeiro(model);

                if (model.CatCnh == null || !model.CatCnh.Any())
                    throw new Exception("Categoria da CNH não preenchida!");

                ModelState.Remove("Cpf");

                if (!ModelState.IsValid) throw new Exception("Campos inválidos!");

                model.ProcessarCategoriaDaCnh();

                var novo = _db.Clientes.Find(model.ClienteId);

                novo.Atualizar(model);

                _db.Entry(novo).State = EntityState.Modified;

                _db.SaveChanges();

                Message("Operação realizada com sucesso!", MessageType.success);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Message(e.Message, MessageType.error);
                return View(model);
            }
        }

        public ActionResult Remover(int id)
        {
            try
            {
                var cliente = _db.Clientes.Find(id);
                cliente.AlterarAtivo();
                _db.SaveChanges();
                Message("Alteração feita com sucesso!", MessageType.success);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Message(e.Message, MessageType.error);
                return RedirectToAction("Index");
            }
        }

        public ActionResult MostrarFotoDePerfil(string cpf)
        {
            var fotoPadrao = $"{_hostEnvironment.WebRootPath}\\Images\\profile.jpg";

            if (string.IsNullOrEmpty(cpf))
                return File(System.IO.File.ReadAllBytes(fotoPadrao), "image/jpeg");

            var diretorio = $"{_hostEnvironment.WebRootPath}\\Uploads\\Perfis\\{cpf.Replace(".", string.Empty).Replace("-", string.Empty)}.jpeg";

            if (!System.IO.File.Exists(diretorio))
                return File(System.IO.File.ReadAllBytes(fotoPadrao), "image/jpeg");

            byte[] imageBytes = System.IO.File.ReadAllBytes(diretorio);

            return File(imageBytes, "image/jpeg");
        }

        public void ValidarEstrangeiro(Cliente model)
        {
            if (model.ClienteEstrangeiro == true)
            {
                if (string.IsNullOrEmpty(model.DocumentoIdentificacaoEstrangeiro)) throw new Exception("Documento do estrangeiro não preenchido!");
            }
            else
            {
                if (string.IsNullOrEmpty(model.Rg)) throw new Exception("RG não preenchido!");
                if (model.OrgaoExpedidorRg == 0) throw new Exception("Orgão expedidor do RG não preenchido!");
                if (model.EstadoOrgaoExpedidor == 0) throw new Exception("Estado emissor do RG não preenchido!");
            }
        }

        private void ProcessarImagemBase64String(string imageBase64String, string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return;

            if (!string.IsNullOrEmpty(imageBase64String))
            {
                string base64 = imageBase64String.Substring("data:image/jpeg;base64,".Length);

                if (IsValidBase64(base64))
                {
                    byte[] imageBytes = Convert.FromBase64String(base64);
                    var physicalPath = $"{_hostEnvironment.WebRootPath}\\Uploads\\Perfis\\{cpf.Replace(".", string.Empty).Replace("-", string.Empty)}.jpeg";
                    System.IO.File.WriteAllBytes(physicalPath, imageBytes);
                }
            }
        }

        private bool IsValidBase64(string base64String)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64String);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}