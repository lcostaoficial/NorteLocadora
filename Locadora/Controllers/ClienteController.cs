using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Locadora.Controllers
{
    public class ClienteController : Controller
    {
        private readonly MainContext _db;

        public ClienteController(MainContext context)
        {
            _db = context;
        }

        public ActionResult Index()
        {
            var list = _db.Clientes.ToList();
            return View(list);
        }       

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Cliente model)
        {
            try
            {
                ValidarEstrangeiro(model);
                if (!ModelState.IsValid) throw new Exception();
                if (!model.ValidarCpf()) throw new Exception("O CPF informado é inválido!");
                var cpfJaExiste = _db.Clientes.Any(x => x.Cpf == model.Cpf);
                if (cpfJaExiste) throw new Exception("O CPF informado já foi utilizado!");
                _db.Clientes.Add(model);
                model.Ativo = true;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            var model = _db.Clientes.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cliente model)
        {
            try
            {
                ValidarEstrangeiro(model);
                ModelState.Remove("Cpf");
                if (!ModelState.IsValid) throw new Exception();
                var novo = _db.Clientes.Find(model.ClienteId);
                novo.Atualizar(model);
                _db.Entry(novo).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ActionResult Remover(int id)
        {
            try
            {
                var cliente = _db.Clientes.Find(id);
                cliente.Inativar();
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
    }
}