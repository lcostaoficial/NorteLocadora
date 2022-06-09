using Locadora.Data;
using Locadora.Models;
using Locadora.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Locadora.Controllers
{
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
            return View();
        }

        public ActionResult DadosPessoais(int? locacaoId = 0)
        {
            if (locacaoId != 0)
            {
                var loc = _db.Locacoes.Include(x => x.Cliente).FirstOrDefault(x => x.Id == locacaoId);
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

        public ActionResult Documentacao(int locacaoId = 0)
        {
            if (locacaoId != 0)
            {
                var loc = _db.Locacoes.Include(x => x.Cliente).FirstOrDefault(x => x.Id == locacaoId);

                var documentacaoVm = new DocumentacaoVm();

                documentacaoVm.IncluirRotasSaida(loc.DocumentoDeContrato, loc.DocumentoDeNadaConstaDetran, loc.DocumentoDeNadaConstaCriminal, loc.DocumentoDeCheckListSaida, loc.DocumentoDeIdentificacao, loc.DocumentoDeComprovanteDeEndereco);

                documentacaoVm.LocacaoId = loc.Id;

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

                    if (!ModelState.IsValid) throw new Exception("Preencha todos os campos corretamente!");
                    if (model.ClienteId == 0 && !model.Cliente.ValidarCpf()) throw new Exception("O CPF informado é inválido!");
                    if (model.Id == 0)
                    {
                        var existemVeiculosDisponiveis = _db.Veiculos.Any(x => x.Locacoes.All(y => y.Devolvido));

                        if (!existemVeiculosDisponiveis)
                            throw new Exception("Não existem veículos disponíveis no sistema!");

                        var cliente = model.ClienteId != 0 ? _db.Clientes.Find(model.ClienteId) : null;

                        if (model.ClienteId != 0)
                        {
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

                        novo.AtualizarCliente(model);

                        _db.Entry(novo).State = EntityState.Modified;
                        _db.SaveChanges();
                        return Json(new { Success = "Os dados pessoais foram alterados com sucesso!", model.Id, novo.ClienteId, novo.VeiculoId });
                    }
                }

                ActionResult AtualizarLocacao()
                {
                    var novo = _db.Locacoes.First(x => x.Id == model.Id);
                    var validacao = novo.AtualizarLocacao(model);
                    if (!validacao) throw new Exception("Preencha todos os campos corretamente!");

                    if (model.DataRetirada.Value.Date > model.DataPrevistaDeDevolucao.Value.Date) throw new Exception("A data de retirada não pode ser maior do que a data prevista para devolução!");


                    _db.Entry(novo).State = EntityState.Modified;
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
                    case IdentificadoDocumentacaoVm.DocumentoDeCheckListSaida:
                        locacao.AtualizarCheckListSaida(rota);
                        break;
                    case IdentificadoDocumentacaoVm.DocumentoDeCheckListChegada:
                        locacao.AtualizarCheckListChegada(rota);
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

        public ActionResult BuscarCpfExistente(string cpf)
        {
            try
            {
                var cliente = _db.Clientes.FirstOrDefault(x => x.Cpf == cpf);
                return Json(new { Success = "Dados da impressão carregados com sucesso!", JaExiste = cliente != null, Model = cliente });
            }
            catch (Exception e)
            {
                return Json(new { Error = e.Message });
            }
        }

        public ActionResult ObterVeiculosDisponiveis(int? veiculoId = 0)
        {
            ViewBag.VeiculoId = veiculoId;

            if (veiculoId == 0)
            {
                var veiculosDisponiveis = _db.Veiculos.Include(x => x.FotosDeGaragem).Where(x => x.Locacoes.All(x => x.Devolvido));
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
                return fileName;
            }
            else
            {
                throw new Exception("Foto não anexada");
            }
        }
    }
}