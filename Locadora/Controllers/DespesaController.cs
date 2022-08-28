using Locadora.Config;
using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Locadora.Controllers
{
    public class DespesaController : Controller
    {
        private readonly MainContext _db;

        public DespesaController(MainContext context)
        {
            _db = context;
        }

        public ActionResult Index()
        {
            var list = _db.Despesas.Where(x => x.Ativa).ToList();
            return View(list);
        }

        public ActionResult Novo()
        {
            ViewBag.Veiculos = _db.Veiculos.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Despesa model)
        {
            if (!ModelState.IsValid) throw new Exception();

            model.Ativar();

            _db.Despesas.Add(model);       

            var novaNotificacao = new Notificacao()
            {
                DataDeExibicao = model.DataDeVencimento.Date.AddDays(-Configuracao.DiasDeAntecedenciasParaDespesa),
                Descricao = $"Existe(m) despesa(s) que exigem atenção ao vencimento.",
                Icone = "warning",
                Rota = string.Empty,
                Lida = false
            };

            _db.Notificacoes.Add(novaNotificacao);

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var model = _db.Despesas.FirstOrDefault(x => x.Id == id);
            ViewBag.Veiculos = _db.Veiculos.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(Despesa model)
        {
            if (!ModelState.IsValid) throw new Exception();

            var novo = _db.Despesas.Find(model.Id);

            var houveAlteracaoNaDataDeVencimento = novo.DataDeVencimento.Date != model.DataDeVencimento;

            novo.Atualizar(model);
            _db.Entry(novo).State = EntityState.Modified;

            if (houveAlteracaoNaDataDeVencimento)
            {
                var novaNotificacao = new Notificacao()
                {
                    DataDeExibicao = model.DataDeVencimento.Date.AddDays(-Configuracao.DiasDeAntecedenciasParaDespesa),
                    Descricao = $"Existe(m) despesa(s) que exigem atenção ao vencimento.",
                    Icone = "warning",
                    Rota = string.Empty,
                    Lida = false
                };

                _db.Notificacoes.Add(novaNotificacao);
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Remover(int id)
        {
            var remover = _db.Despesas.Find(id);
            remover.Excluir();
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
