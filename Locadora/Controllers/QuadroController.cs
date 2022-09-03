using Locadora.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Locadora.Controllers
{
    [Authorize]
    public class QuadroController : Controller
    {
        private readonly MainContext _db;

        public QuadroController(MainContext context)
        {
            _db = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LocacoesQuadroGeral()
        {
            var tarefas = _db.Locacoes.Where(x => x.Finalizada && !x.Devolvido).Include(x => x.Cliente).Include(x => x.Veiculo).ToList().Select(x => new
            {
                id = x.Id,
                title = $"Veículo {x.Veiculo.Marca} {x.Veiculo.Modelo} - Placa: {x.Veiculo.Placa} ",
                description = "",
                start = x.DataRetirada?.ToString("yyyy-MM-dd"),
                end = x.DataPrevistaDeDevolucao?.ToString("yyyy-MM-dd"),
                className = x.LocacaoAtrasada ? "bg-warning" : "bg-success",
                author = x.Cliente.Nome
            });

            return Json(tarefas);
        }
    }
}
