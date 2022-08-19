using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Locadora.Controllers
{
    public class MultaController : Controller
    {
        private readonly MainContext _db;

        public MultaController(MainContext context)
        {
            _db = context;
        }

        public ActionResult Index()
        {
            var list = _db.Multas.Where(x => x.Ativo).ToList();
            return View(list);
        }

        public ActionResult Novo()
        {
            ViewBag.Veiculos = _db.Veiculos.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Multa model)
        {
            if (!ModelState.IsValid) throw new Exception();
            model.Ativar();
            _db.Multas.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var model = _db.Multas.FirstOrDefault(x => x.Id == id);
            ViewBag.Veiculos = _db.Veiculos.ToList();
            return View(model);
        }

        [HttpPost]    
        public ActionResult Editar(Multa model)
        {
            if (!ModelState.IsValid) throw new Exception();
            var novo = _db.Multas.Find(model.Id);
            novo.Atualizar(model);
            _db.Entry(novo).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Remover(int id)
        {
            var multa = _db.Multas.Find(id);
            multa.Excluir();
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}