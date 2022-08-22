using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Locadora.Controllers
{
    public class AcessorioController : Controller
    {
        private readonly MainContext _db;

        public AcessorioController(MainContext context)
        {
            _db = context;
        }

        public ActionResult Index()
        {
            var list = _db.Acessorios.Where(x => x.Ativo).ToList();
            return View(list);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Acessorio model)
        {
            if (!ModelState.IsValid) throw new Exception();
            model.Ativar();
            _db.Acessorios.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var model = _db.Acessorios.FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(Acessorio model)
        {
            if (!ModelState.IsValid) throw new Exception();
            var novo = _db.Acessorios.Find(model.Id);
            novo.Atualizar(model);
            _db.Entry(novo).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Remover(int id)
        {
            var multa = _db.Acessorios.Find(id);
            multa.Excluir();
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
