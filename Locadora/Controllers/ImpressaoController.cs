using Locadora.Data;
using Locadora.Helpers;
using Locadora.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace Locadora.Controllers
{
    public class ImpressaoController : Controller
    {
        private readonly MainContext _db;

        public ImpressaoController(MainContext context)
        {
            _db = context;
        }

        public ActionResult ImprimirContrato(int locacaoId)
        {
            try
            {
                if (locacaoId == 0) 
                    throw new Exception("Ocorreu um erro ao tentar imprimir o contrato.");

                var locacao = _db.Locacoes.Include(x => x.Cliente).Include(x => x.Veiculo).First(x => x.Id == locacaoId);

                var contrato = new ContratoVm()
                {
                    Cpf = locacao.Cliente.Cpf,
                    DataRetiradaFormatada = locacao.DataRetirada.Value.ToString("dd/MM/yyyy 'às' HH:mm"),
                    DataDevolucaoFormatada = locacao.DataPrevistaDeDevolucao.Value.ToString("dd/MM/yyyy 'às' HH:mm"),
                    TipoVeiculo = locacao.Veiculo.TipoDeVeiculo.ToString(),
                    DataDoContratoPorExtenso = $"{DateTime.Now.Day} de {DateTime.Now.ToString("MMMM", new CultureInfo("pt-BR"))} de {DateTime.Now.Year}",
                    ValorDaLocacaoPorExtenso = MoneyUtils.EscreverExtenso(locacao.PrecoCombinado.Value),  
                    ValorDaLocacao = locacao.PrecoCombinado.ToString(),
                    Nome = locacao.Cliente.Nome.ToUpper(),
                    Rg = locacao.Cliente.Rg,
                    EstadoRg = locacao.Cliente.EstadoOrgaoExpedidor.ToString(),
                    Cep = locacao.Cliente.Cep.ToString(),
                    Rua = locacao.Cliente.Rua,
                    Numero = locacao.Cliente.Numero,
                    Cidade = locacao.Cliente.Cidade.ToString(),
                    Bairro = locacao.Cliente.Bairro.ToString(),
                    Estado = locacao.Cliente.Estado.ToString(),
                    OrgaoExpedidorRg = locacao.Cliente.OrgaoExpedidorRg.ToString(),
                    AnoDeFabricacao = locacao.Veiculo.AnoDeFabricacao.ToString(),
                    AnoDeModelo = locacao.Veiculo.AnoDeModelo.ToString(),
                    Marca = locacao.Veiculo.Marca.ToString(),
                    Modelo = locacao.Veiculo.Modelo.ToString(),
                    TipoDeVeiculo = locacao.Veiculo.TipoDeVeiculo.ToString(),
                    Placa = locacao.Veiculo.Placa,
                    ValorFipe = locacao.Veiculo.ValorFipe.ToString()
                };

                return Json(new { Success = "Dados da impressão carregados com sucesso!", Model = contrato });
            }
            catch (Exception e)
            {
                return Json(new { Error = e.Message });
            }
        }
    }
}