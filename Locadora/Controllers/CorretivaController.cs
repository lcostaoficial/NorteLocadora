using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Locadora.Controllers
{
    public class CorretivaController : Controller
    {
        private readonly MainContext _db;

        public CorretivaController(MainContext context)
        {
            _db = context;
        }

        public ActionResult Index()
        {
            var list = _db.Manutencoes.Include(x => x.Veiculo).Where(x => x.Ativo && x.TipoManutencao == TipoManutencao.Corretiva).ToList();
            return View(list);
        }

        public ActionResult Novo()
        {
            ViewBag.Veiculos = _db.Veiculos.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Manutencao model)
        {
            if (!ModelState.IsValid) throw new Exception();
            model.Ativar();
            model.ConfigurarComoCorretiva();
            _db.Manutencoes.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var model = _db.Manutencoes.FirstOrDefault(x => x.Id == id && x.TipoManutencao == TipoManutencao.Corretiva);
            ViewBag.Veiculos = _db.Veiculos.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(Manutencao model)
        {
            if (!ModelState.IsValid) throw new Exception();
            var novo = _db.Manutencoes.Find(model.Id);
            novo.Atualizar(model);
            _db.Entry(novo).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Remover(int id)
        {
            var remover = _db.Manutencoes.Find(id);
            remover.Excluir();
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}