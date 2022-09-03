﻿using Locadora.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Locadora.Controllers
{
    [Authorize]
    public class NotificacaoController : Controller
    {
        private readonly MainContext _db;

        public NotificacaoController(MainContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var list = _db.Notificacoes.Where(x => x.Lida && x.Ativa).OrderByDescending(x => x.Id);          
            return View(list);
        }

        public IActionResult Exibir(int id)
        {
            var notificacao = _db.Notificacoes.Find(id);
            notificacao.LerNotificacao();
            _db.SaveChanges();
            return PartialView("_Notificacao", notificacao);
        }
    }
}
