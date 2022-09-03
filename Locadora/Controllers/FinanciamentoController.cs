﻿using Locadora.Config;
using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Controllers
{
    [Authorize]
    public class FinanciamentoController : Controller
    {
        private readonly MainContext _db;

        public FinanciamentoController(MainContext context)
        {
            _db = context;
        }

        public ActionResult Index()
        {
            var list = _db.Financiamentos.Include(x => x.Parcelas).Include(x => x.Veiculo).Where(x => x.Ativo).ToList();
            return View(list);
        }

        public ActionResult ParcelasDoFinanciamento(int financiamentoId)
        {
            var parcelas = _db.ParcelasDoFinanciamento.Where(x => x.FinanciamentoId == financiamentoId).ToList();
            return PartialView("_Parcelas", parcelas);
        }

        public ActionResult QuitarParcela(int parcelaId, decimal valorPago)
        {
            var parcela = _db.ParcelasDoFinanciamento.Find(parcelaId);

            if (!parcela.AtualizarValorPago(valorPago))
                return Json(new { Error = true, Msg = "O valor pago não pode ser inferior ao valor da parcela!" });

            _db.SaveChanges();

            return Json(new { Success = true, FinanciamentoId = parcela.FinanciamentoId });
        }

        public ActionResult Novo()
        {
            ViewBag.Veiculos = _db.Veiculos.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Financiamento model)
        {
            if (!ModelState.IsValid) throw new Exception();

            model.Ativar();

            model.GerarParcelasDoFinanciamento();

            _db.Financiamentos.Add(model);

            var veiculo = _db.Veiculos.Find(model.VeiculoId);

            if (model.Parcelas != null && model.Parcelas.Any())
            {
                var notificacoes = new List<Notificacao>();

                foreach (var item in model.Parcelas)
                {
                    var novaNotificacao = new Notificacao()
                    {
                        DataDeExibicao = item.DataDeVencimento.Date.AddDays(-Configuracao.DiasDeAntecedenciasParaParcelasDeFinanciamento),
                        Descricao = $"O veículo de placa: {veiculo.Placa} necessita de atenção ao vencimento da parcela do seu financiamento.",
                        Icone = "warning",
                        Rota = string.Empty,
                        Lida = false
                    };

                    notificacoes.Add(novaNotificacao);
                }

                _db.Notificacoes.AddRange(notificacoes);
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Remover(int id)
        {
            var model = _db.Financiamentos.Find(id);
            model.Excluir();
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
