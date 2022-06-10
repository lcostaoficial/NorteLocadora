using Locadora.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Locadora.Controllers
{
    public class DevolucaoController : Controller
    {
        private readonly MainContext _db;

        public DevolucaoController(MainContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var locacoesParaDevolucao = _db.Locacoes.Include(x => x.Cliente).Where(x => x.Finalizada && !x.Devolvido);
            return View(locacoesParaDevolucao);
        }
    }
}