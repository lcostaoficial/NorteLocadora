using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        public IActionResult Novo(int id)
        {
            var locacao = _db.Locacoes.Include(x => x.Acessorios).Include(x => x.Veiculo.FotosDeGaragem).FirstOrDefault(x => x.Finalizada && !x.Devolvido && x.Id == id);
            locacao.QuilometragemDeDevolucao = locacao.Veiculo.Quilometragem;
            return View(locacao);
        }

        [HttpPost]
        public ActionResult Novo(Locacao model)
        {
            try
            {
                if (model.Id == 0)
                    throw new Exception("Protocolo não informado");

                var novo = _db.Locacoes.Find(model.Id);

                var validacao = novo.AtualizarDevolucaoDaLocacao(model);

                if (!validacao) throw new Exception("Preencha todos os campos corretamente!");

                novo.FinalizarDevolucao();

                var veiculo = _db.Veiculos.Find(novo.VeiculoId);
                
                veiculo.AtualizarQuilometragem(model.QuilometragemDeDevolucao.Value);

                var preventiva = _db.Manutencoes.FirstOrDefault(x => (x.TipoManutencao == TipoManutencao.Preventiva || x.Data.Date >= DateTime.Now.Date) && (veiculo.Quilometragem >= x.Quilometragem && x.Data.Date >= DateTime.Now.Date) && x.VeiculoId == veiculo.Id && x.Ativo);

                if (preventiva != null)
                {
                    var novaNotificacao = new Notificacao()
                    {
                        DataDeExibicao = DateTime.Now,
                        Descricao = $"O veículo de placa: {veiculo.Placa} necessita realizar manutenção preventiva.",
                        Icone = "warning",
                        Rota = $"/Preventiva/Editar?id={preventiva.Id}",
                        Lida = false
                    };

                    _db.Notificacoes.Add(novaNotificacao);
                }

                _db.Entry(novo).State = EntityState.Modified;

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}