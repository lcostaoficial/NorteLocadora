﻿using Locadora.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Locadora.Controllers
{
    public class FinanciamentoController : Controller
    {
        private readonly MainContext _db;

        public FinanciamentoController(MainContext context)
        {
            _db = context;
        }

        public ActionResult Index()
        {
            var list = _db.Financiamentos.Where(x => x.Ativo).ToList();
            return View(list);
        }

        //public ActionResult Novo()
        //{
        //    ViewBag.Veiculos = _db.Veiculos.ToList();
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Novo(Multa model)
        //{
        //    if (!ModelState.IsValid) throw new Exception();

        //    model.Ativar();

        //    _db.Multas.Add(model);

        //    var veiculo = _db.Veiculos.Find(model.VeiculoId);

        //    var novaNotificacao = new Notificacao()
        //    {
        //        DataDeExibicao = model.DataDeVencimento.Date.AddDays(Configuracao.DiasDeAntecedenciasParaMulta),
        //        Descricao = $"O veículo de placa: {veiculo.Placa} necessita de atenção ao vencimento de multa cadastrada.",
        //        Icone = "warning",
        //        Rota = string.Empty,
        //        Lida = false
        //    };

        //    _db.Notificacoes.Add(novaNotificacao);

        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Editar(int id)
        //{
        //    var model = _db.Multas.FirstOrDefault(x => x.Id == id);
        //    ViewBag.Veiculos = _db.Veiculos.ToList();
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Editar(Multa model)
        //{
        //    if (!ModelState.IsValid) throw new Exception();

        //    var novo = _db.Multas.Find(model.Id);

        //    var houveAlteracaoNaDataDeVencimento = novo.DataDeVencimento.Date != model.DataDeVencimento;

        //    novo.Atualizar(model);
        //    _db.Entry(novo).State = EntityState.Modified;

        //    var veiculo = _db.Veiculos.Find(model.VeiculoId);

        //    if (houveAlteracaoNaDataDeVencimento)
        //    {
        //        var novaNotificacao = new Notificacao()
        //        {
        //            DataDeExibicao = model.DataDeVencimento.Date.AddDays(Configuracao.DiasDeAntecedenciasParaMulta),
        //            Descricao = $"O veículo de placa: {veiculo.Placa} necessita de atenção ao vencimento de multa cadastrada.",
        //            Icone = "warning",
        //            Rota = string.Empty,
        //            Lida = false
        //        };

        //        _db.Notificacoes.Add(novaNotificacao);
        //    }

        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Remover(int id)
        //{
        //    var multa = _db.Multas.Find(id);
        //    multa.Excluir();
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}