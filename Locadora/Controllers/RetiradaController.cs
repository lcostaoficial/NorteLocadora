using Locadora.Data;
using Locadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Locadora.Controllers
{
    public class RetiradaController : Controller
    {
        private readonly MainContext _db;

        public RetiradaController(MainContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult DadosPessoais(int? locacaoId = 0)
        {
            if (locacaoId != 0)
            {
                var caso = _db.Locacoes.Include(x => x.Cliente).FirstOrDefault(x => x.Id == locacaoId);
                return PartialView("_DadosPessoais", caso);
            }
            else

            {
                return PartialView("_DadosPessoais");
            }
        }

        [HttpPost]
        public ActionResult SalvarLocacaoComDadosPessoais(Locacao model)
        {
            try
            {
                ValidarEstrangeiro(model);

                ModelState.Remove("Nome");
                ModelState.Remove("Cpf");
                ModelState.Remove("DataNascimento");

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
                    var cliente = model.ClienteId != 0 ? _db.Clientes.Find(model.ClienteId) : null;

                    if (model.ClienteId != 0)
                    {
                        cliente.Atualizar(model.Cliente);
                        _db.Entry(cliente).State = EntityState.Modified;
                        model.Cliente = null;
                    }

                    //model.Data = DateTime.Now;
                    //model.SituacaoCaso = SituacaoCaso.Pendente;
                    //model.Ativo = true;

                    var retorno = _db.Locacoes.Add(model);

                    _db.SaveChanges();

                    return Json(new { Success = "Os dados pessoais foram salvos com sucesso!", model.Id });
                }
                else
                {
                    var novo = _db.Locacoes.Include(x => x.Cliente).First(x => x.Id == model.Id);

                    novo.AtualizarCliente(model);

                    _db.Entry(novo).State = EntityState.Modified;
                    _db.SaveChanges();
                    return Json(new { Success = "Os dados pessoais foram alterados com sucesso!", model.Id, novo.ClienteId });
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
                return Json(new { Success = "Dados da impressão carregados com sucesso!", JaExiste = cliente != null, Model = cliente });
            }
            catch (Exception e)
            {
                return Json(new { Error = e.Message });
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
    }
}