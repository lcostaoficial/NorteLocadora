using Locadora.Data;
using Locadora.Helpers;
using Locadora.Models;
using Locadora.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Controllers
{
    [Authorize]
    public class RetiradaController : Controller
    {
        private readonly MainContext _db;
        private IWebHostEnvironment _hostEnvironment;

        public RetiradaController(MainContext context, IWebHostEnvironment hostEnvironment)
        {
            _db = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var list = _db.Locacoes.Include(x => x.Cliente);
            return View(list);
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var locacao = _db.Locacoes.Include(x => x.Veiculo).FirstOrDefault(x => x.Id == id);
            ViewBag.LocacaoId = id;
            ViewBag.VeiculoId = locacao.VeiculoId;
            ViewBag.HabilitarDocumentacaoParcial = locacao.PossuiAlgumaDocumentacaoAnexada() ? true : false;
            ViewBag.HabilitarDocumentacaoCompleta = locacao.PossuiDocumentacaoPreenchidaCompleta() ? true : false;
            ViewBag.HabilitarLocacao = locacao.PossuiLocacaoPreenchidaCompleta() ? true : false;
            return View("Novo", locacao);
        }

        public ActionResult DadosPessoais(int? locacaoId = 0)
        {
            if (locacaoId != 0)
            {
                var loc = _db.Locacoes.Include(x => x.Cliente).FirstOrDefault(x => x.Id == locacaoId);

                loc.Cliente.CarrregarCategoriaDaCnh();

                return PartialView("_DadosPessoais", loc);
            }
            else

            {
                return PartialView("_DadosPessoais");
            }
        }

        public ActionResult Locacao(int? locacaoId = 0)
        {
            if (locacaoId != 0)
            {
                var loc = _db.Locacoes.Include(x => x.Cliente).FirstOrDefault(x => x.Id == locacaoId);
                return PartialView("_Locacao", loc);
            }
            else
            {
                return PartialView("_Locacao");
            }
        }

        public ActionResult ReaproveitarDocumentacaoDaLocacaoAnterior(int locacaoId = 0, IdentificadoDocumentacaoVm tipoDocumento = 0)
        {
            try
            {
                if (locacaoId != 0 && tipoDocumento != IdentificadoDocumentacaoVm.Nenhum)
                {
                    var loc = _db.Locacoes.Include(x => x.Cliente).FirstOrDefault(x => x.Id == locacaoId);

                    var locAnterior = _db.Locacoes.OrderByDescending(x => x.Id).FirstOrDefault(x => x.Id != loc.Id && x.ClienteId == loc.ClienteId);

                    if (locAnterior != null)
                    {
                        switch (tipoDocumento)
                        {
                            case IdentificadoDocumentacaoVm.Nenhum:
                                break;
                            case IdentificadoDocumentacaoVm.DocumentoDeContrato:

                                if (string.IsNullOrEmpty(locAnterior.DocumentoDeContrato))
                                    throw new Exception("Sem documentação anterior!");

                                loc.DocumentoDeContrato = locAnterior.DocumentoDeContrato;
                                _db.SaveChanges();
                                break;
                            case IdentificadoDocumentacaoVm.DocumentoDeNadaConstaDetran:

                                if (string.IsNullOrEmpty(locAnterior.DocumentoDeNadaConstaDetran))
                                    throw new Exception("Sem documentação anterior!");

                                loc.DocumentoDeNadaConstaDetran = locAnterior.DocumentoDeNadaConstaDetran;
                                _db.SaveChanges();
                                break;
                            case IdentificadoDocumentacaoVm.DocumentoDeNadaConstaCriminal:

                                if (string.IsNullOrEmpty(locAnterior.DocumentoDeNadaConstaCriminal))
                                    throw new Exception("Sem documentação anterior!");

                                loc.DocumentoDeNadaConstaCriminal = locAnterior.DocumentoDeNadaConstaCriminal;
                                _db.SaveChanges();
                                break;
                            case IdentificadoDocumentacaoVm.DocumentoDeIdentificacao:

                                if (string.IsNullOrEmpty(locAnterior.DocumentoDeIdentificacao))
                                    throw new Exception("Sem documentação anterior!");

                                loc.DocumentoDeIdentificacao = locAnterior.DocumentoDeIdentificacao;
                                _db.SaveChanges();
                                break;
                            case IdentificadoDocumentacaoVm.DocumentoDeComprovanteDeEndereco:

                                if (string.IsNullOrEmpty(locAnterior.DocumentoDeComprovanteDeEndereco))
                                    throw new Exception("Sem documentação anterior!");

                                loc.DocumentoDeComprovanteDeEndereco = locAnterior.DocumentoDeComprovanteDeEndereco;
                                _db.SaveChanges();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        throw new Exception("Não existem locações anteriores finalizadas para o cliente em tela");
                    }

                    var documentacaoVm = new DocumentacaoVm();

                    documentacaoVm.IncluirRotasSaida(loc.DocumentoDeContrato, loc.DocumentoDeNadaConstaDetran, loc.DocumentoDeNadaConstaCriminal, loc.DocumentoDeIdentificacao, loc.DocumentoDeComprovanteDeEndereco);

                    documentacaoVm.LocacaoId = loc.Id;

                    documentacaoVm.Finalizada = loc.Finalizada;

                    return Json(new { Success = "Ok" });
                }
                else
                {
                    throw new Exception("Ocorreu um erro ao carregar a documentação");
                }
            }
            catch (Exception e)
            {
                return Json(new { Error = e.Message });
            }
        }

        public ActionResult Documentacao(int locacaoId = 0)
        {
            if (locacaoId != 0)
            {
                var loc = _db.Locacoes.Include(x => x.Cliente).FirstOrDefault(x => x.Id == locacaoId);

                var documentacaoVm = new DocumentacaoVm();

                documentacaoVm.IncluirRotasSaida(loc.DocumentoDeContrato, loc.DocumentoDeNadaConstaDetran, loc.DocumentoDeNadaConstaCriminal, loc.DocumentoDeIdentificacao, loc.DocumentoDeComprovanteDeEndereco);

                documentacaoVm.LocacaoId = loc.Id;

                documentacaoVm.Finalizada = loc.Finalizada;

                return PartialView("_Documentacao", documentacaoVm);
            }
            else
            {
                throw new Exception("Ocorreu um erro ao carregar a documentação");
            }
        }

        [HttpPost]
        public ActionResult SalvarLocacao(Locacao model, string Step)
        {
            try
            {
                if (string.IsNullOrEmpty(Step))
                    throw new Exception("Step inválido");

                ActionResult AtualizarDadosPessoais()
                {
                    if (model.Cliente.CatCnh == null || !model.Cliente.CatCnh.Any())
                        throw new Exception("Categoria da CNH não preenchida!");

                    ProcessarImagemBase64String(model.Cliente.ImageBase64String, model.Cliente.Cpf);

                    ValidarEstrangeiro(model);

                    ModelState.Remove("Nome");
                    ModelState.Remove("Cpf");
                    ModelState.Remove("DataNascimento");
                    ModelState.Remove("DataRetirada");
                    ModelState.Remove("DataPrevistaDeDevolucao");
                    ModelState.Remove("PrecoCombinado");

                    if (model.Id == 0) ModelState.Remove("Id");

                    if (model.ClienteId != 0) ModelState.Remove("Cliente.Cpf");

                    if (model.Cliente.ClienteEstrangeiro == true)
                    {
                        ModelState.Remove("Cliente.Rg");
                        ModelState.Remove("Cliente.OrgaoExpedidorRg");
                        ModelState.Remove("Cliente.EstadoOrgaoExpedidor");
                    }
                    else
                    {
                        ModelState.Remove("DocumentoEstrangeiro");
                    }

                    if (!ModelState.IsValid) 
                        throw new Exception("Preencha todos os campos corretamente!");

                    if (model.ClienteId == 0 && !model.Cliente.ValidarCpf()) 
                        throw new Exception("O CPF informado é inválido!");

                    if (model.Id == 0)
                    {
                        var existemVeiculosDisponiveis = _db.Veiculos.Any(x => x.Locacoes.All(y => y.Devolvido));

                        if (!existemVeiculosDisponiveis)
                            throw new Exception("Não existem veículos disponíveis no sistema!");

                        model.Cliente.ProcessarCategoriaDaCnh();

                        var cliente = model.ClienteId != 0 ? _db.Clientes.Find(model.ClienteId) : null;

                        if (model.ClienteId != 0)
                        {
                            cliente.ProcessarCategoriaDaCnh(model.Cliente.CatCnh);
                            cliente.Atualizar(model.Cliente);
                            _db.Entry(cliente).State = EntityState.Modified;
                            model.Cliente = null;
                        }

                        var retorno = _db.Locacoes.Add(model);

                        _db.SaveChanges();

                        return Json(new { Success = "Os dados pessoais foram salvos com sucesso!", model.Id, veiculoId = model.VeiculoId ?? 0 });
                    }
                    else
                    {     
                        var novo = _db.Locacoes.Include(x => x.Cliente).First(x => x.Id == model.Id);

                        novo.Cliente.CatCnh = model.Cliente.CatCnh;

                        novo.AtualizarCliente(model);

                        novo.Cliente.ProcessarCategoriaDaCnh();

                        _db.Entry(novo).State = EntityState.Modified;

                        _db.SaveChanges();
                        return Json(new { Success = "Os dados pessoais foram alterados com sucesso!", model.Id, novo.ClienteId, novo.VeiculoId });
                    }
                }

                ActionResult AtualizarLocacao()
                {
                    var veiculosDisponiveis = _db.Veiculos.Any(x => x.Locacoes.All(x => x.Devolvido));

                    if (!veiculosDisponiveis)
                        throw new Exception("Nenhum veículo disponível para concluir a operação!");

                    var novo = _db.Locacoes.First(x => x.Id == model.Id);
                    var validacao = novo.AtualizarLocacao(model);
                    if (!validacao) throw new Exception("Preencha todos os campos corretamente!");

                    if (model.DataRetirada.Value.Date > model.DataPrevistaDeDevolucao.Value.Date) throw new Exception("A data de retirada não pode ser maior do que a data prevista para devolução!");

                    _db.SaveChanges();
                    return Json(new { Success = "A locação foi salva com sucesso!", LocacaoId = novo.Id, novo.VeiculoId });
                }

                if (Step == "DadosPessoais")
                    return AtualizarDadosPessoais();

                if (Step == "Locacao")
                    return AtualizarLocacao();

                throw new Exception($"O step {Step} não foi localizado!");
            }
            catch (Exception e)
            {
                return Json(new { Error = e.Message });
            }
        }

        [HttpPost]
        public ActionResult SalvarAnexo(int id, IdentificadoDocumentacaoVm identificador, IFormFile arquivoBinario)
        {
            try
            {
                if (identificador == IdentificadoDocumentacaoVm.Nenhum)
                    throw new Exception("Identificador do arquivo não encontrado!");

                if (arquivoBinario == null) throw new Exception("Por favor anexe o arquivo!");

                var rota = AnexarDocumento(arquivoBinario, id);

                var locacao = _db.Locacoes.Find(id);

                switch (identificador)
                {
                    case IdentificadoDocumentacaoVm.DocumentoDeContrato:
                        locacao.AtualizarContrato(rota);
                        break;
                    case IdentificadoDocumentacaoVm.DocumentoDeNadaConstaDetran:
                        locacao.AtualizarNadaConstaDetran(rota);
                        break;
                    case IdentificadoDocumentacaoVm.DocumentoDeNadaConstaCriminal:
                        locacao.AtualizarNadaConstaCriminal(rota);
                        break;
                    case IdentificadoDocumentacaoVm.DocumentoDeIdentificacao:
                        locacao.AtualizarDocumentoDeIdentificacao(rota);
                        break;
                    case IdentificadoDocumentacaoVm.DocumentoDeComprovanteDeEndereco:
                        locacao.AtualizarComprovanteDeEndereco(rota);
                        break;
                }

                _db.SaveChanges();
                return Json(new { Success = "Documento anexado com sucesso!" });
            }
            catch (Exception e)
            {
                return Json(new { Error = e.Message });
            }
        }

        public ActionResult FinalizarLocacao(int locacaoId)
        {
            try
            {
                var locacao = _db.Locacoes.Find(locacaoId);

                var locacaoValidada = locacao.ValidarCamposLocacao();

                var documentacaoValidada = locacao.ValidarDocumentacaoRetirada();

                if (locacaoValidada && documentacaoValidada)
                {
                    locacao.FinalizarLocacao();

                    var veiculo = _db.Veiculos.Find(locacao.VeiculoId);

                    if (locacao.QuilometragemAtual.HasValue)
                        veiculo.AtualizarQuilometragem(locacao.QuilometragemAtual.Value);

                    //var preventiva = _db.Manutencoes.FirstOrDefault(x => (x.TipoManutencao == TipoManutencao.Preventiva || x.Data.Date >= DateTime.Now.Date) && (locacao.QuilometragemAtual >= x.Quilometragem && x.Data.Date >= DateTime.Now.Date) && x.VeiculoId == veiculo.Id && x.Ativo);

                    //if (preventiva != null)
                    //{
                    //    var novaNotificacao = new Notificacao()
                    //    {
                    //        DataDeExibicao = DateTime.Now,
                    //        Descricao = $"O veículo de placa: {veiculo.Placa} necessita realizar uma manutenção.",
                    //        Icone = "warning",
                    //        Rota = $"/Preventiva/Editar?id={preventiva.Id}",
                    //        Lida = false
                    //    };

                    //    _db.Notificacoes.Add(novaNotificacao);
                    //}

                    _db.SaveChanges();

                    return Json(new { Success = "Locação finalizada com sucesso!" });
                }
                else
                {
                    throw new Exception("Não foi possível finalizar a locação!");
                }
            }
            catch (Exception e)
            {
                return Json(new { Error = e.Message });
            }
        }

        public ActionResult BuscarCpfExistente(string cpf)
        {
            try
            {
                var cliente = _db.Clientes.FirstOrDefault(x => x.Cpf == cpf);

                if (cliente != null)
                    cliente.CarrregarCategoriaDaCnh();

                return Json(new { Success = "Dados da impressão carregados com sucesso!", JaExiste = cliente != null, Model = cliente });
            }
            catch (Exception e)
            {
                return Json(new { Error = e.Message });
            }
        }

        public async Task<ActionResult> ObterVeiculosDisponiveis(int? veiculoId = 0)
        {
            ViewBag.VeiculoId = veiculoId;

            if (veiculoId == 0)
            {
                var veiculosDisponiveis = await _db.Veiculos.Include(x => x.FotosDeGaragem).Where(x => x.Locacoes.All(x => x.Devolvido)).ToListAsync();
                return PartialView("_VeiculosDisponiveis", veiculosDisponiveis);
            }
            else
            {
                var veiculosDisponiveis = _db.Veiculos.Where(x => x.Id == veiculoId);
                return PartialView("_VeiculosDisponiveis", veiculosDisponiveis);
            }
        }

        public void ValidarEstrangeiro(Locacao model)
        {
            if (model.Cliente.ClienteEstrangeiro == true)
            {
                if (string.IsNullOrEmpty(model.Cliente.DocumentoIdentificacaoEstrangeiro)) throw new Exception("Documento do estrangeiro não preenchido!");
            }
            else
            {
                if (string.IsNullOrEmpty(model.Cliente.Rg)) throw new Exception("RG não preenchido!");
                if (model.Cliente.OrgaoExpedidorRg == 0) throw new Exception("Orgão expedidor do RG não preenchido!");
                if (model.Cliente.EstadoOrgaoExpedidor == 0) throw new Exception("Estado emissor do RG não preenchido!");
            }
        }

        private string AnexarDocumento(IFormFile arquivoBinario, int locacaoId)
        {
            var allowedExtensions = new List<string> { ".pdf" };

            var physicalPath = $"{_hostEnvironment.WebRootPath}\\Uploads\\Locacao\\{locacaoId}";

            if (arquivoBinario != null && arquivoBinario.Length > 0)
            {
                string extension = Path.GetExtension(arquivoBinario.FileName);

                if (!allowedExtensions.Contains(extension.ToLower()))
                    throw new Exception("Extensão não permitida");

                if (!Directory.Exists(physicalPath))
                    Directory.CreateDirectory(physicalPath);

                if (!Directory.Exists(physicalPath))
                    throw new Exception($"Diretório {physicalPath} não existe!");

                string fileName = $"{Guid.NewGuid()}{extension}";

                string filePath = Path.Combine(physicalPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    arquivoBinario.CopyTo(stream);
                }

                return $@"~/Uploads/Locacao/{locacaoId}/{fileName}";
            }
            else
            {
                throw new Exception("Foto não anexada");
            }
        }

        private void ProcessarImagemBase64String(string imageBase64String, string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return;

            if (!string.IsNullOrEmpty(imageBase64String))
            {
                string base64 = imageBase64String.Substring("data:image/jpeg;base64,".Length);

                if (IsValidBase64(base64))
                {
                    byte[] imageBytes = Convert.FromBase64String(base64);
                    var physicalPath = $"{_hostEnvironment.WebRootPath}\\Uploads\\Perfis\\{cpf.Replace(".", string.Empty).Replace("-", string.Empty)}.jpeg";
                    System.IO.File.WriteAllBytes(physicalPath, imageBytes);
                }
            }
        }

        private bool IsValidBase64(string base64String)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64String);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}