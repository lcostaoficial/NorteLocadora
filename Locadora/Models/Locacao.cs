using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Locadora.Models
{
    public class Locacao
    {
        public int Id { get; set; }

        [Display(Name = "Data de Retirada")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? DataRetirada { get; set; }

        [Display(Name = "Data de Devolução")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? DataPrevistaDeDevolucao { get; set; }

        [Display(Name = "Preço combinado")]
        public decimal? PrecoCombinado { get; set; }

        [Display(Name = "Data de Devolução")]
        public DateTime? DataDeDevolucao { get; set; }

        [Display(Name = "KM de Saída")]
        public int? QuilometragemAtual { get; set; }

        [Display(Name = "KM de Chegada")]
        public int? QuilometragemDeDevolucao { get; set; }

        [Display(Name = "Observações de saída")]
        public string ObservacoesDeSaida { get; set; }

        [Display(Name = "Observações de chegada")]
        public string ObservacoesDeChegada { get; set; }

        public ICollection<Acessorio> Acessorios { get; set; }

        public bool LocacaoAtrasada
        {
            get
            {
                if (DataPrevistaDeDevolucao.HasValue)
                {
                    if (DataPrevistaDeDevolucao.Value < DateTime.Now)
                        return true;
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        [NotMapped]
        public TimeSpan HorarioDeSaida
        {
            get
            {
                if (DataRetirada.HasValue)
                {
                    return new TimeSpan(DataRetirada.Value.Hour, DataRetirada.Value.Minute, DataRetirada.Value.Second);
                }
                else
                {
                    return new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                }
            }
            set
            {
                DataRetirada = DataRetirada.Value.AddHours(value.Hours);
                DataRetirada = DataRetirada.Value.AddMinutes(value.Minutes);
            }
        }


        [NotMapped]
        public TimeSpan HorarioDeChegada
        {
            get
            {
                if (DataPrevistaDeDevolucao.HasValue)
                {
                    return new TimeSpan(DataPrevistaDeDevolucao.Value.Hour, DataPrevistaDeDevolucao.Value.Minute, DataPrevistaDeDevolucao.Value.Second);
                }
                else
                {
                    return new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                }
            }
            set
            {
                DataPrevistaDeDevolucao = DataPrevistaDeDevolucao.Value.AddHours(value.Hours);
                DataPrevistaDeDevolucao = DataPrevistaDeDevolucao.Value.AddMinutes(value.Minutes);
            }
        }

        public string DocumentoDeContrato { get; set; }
        public string DocumentoDeNadaConstaDetran { get; set; }
        public string DocumentoDeNadaConstaCriminal { get; set; }
        public string DocumentoDeCheckListSaida { get; set; }
        public string DocumentoDeCheckListChegada { get; set; }
        public string DocumentoDeIdentificacao { get; set; }
        public string DocumentoDeComprovanteDeEndereco { get; set; }

        public int? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public bool Finalizada { get; set; } = false;

        public bool Devolvido { get; set; }

        public void FinalizarLocacao()
        {
            Finalizada = true;
        }

        public void FinalizarDevolucao()
        {
            Devolvido = true;
        }

        public bool ValidarCamposLocacao()
        {
            if (DataRetirada == null)
                return false;

            if (DataPrevistaDeDevolucao == null)
                return false;

            if (PrecoCombinado == null)
                return false;

            if (VeiculoId == null || VeiculoId == 0)
                return false;

            return true;
        }

        public bool ValidarDocumentacaoRetirada()
        {
            if (string.IsNullOrEmpty(DocumentoDeContrato))
                return false;

            if (string.IsNullOrEmpty(DocumentoDeNadaConstaDetran))
                return false;

            if (string.IsNullOrEmpty(DocumentoDeNadaConstaCriminal))
                return false;

            if (string.IsNullOrEmpty(DocumentoDeCheckListSaida))
                return false;

            if (string.IsNullOrEmpty(DocumentoDeIdentificacao))
                return false;

            if (string.IsNullOrEmpty(DocumentoDeComprovanteDeEndereco))
                return false;

            return true;
        }

        public bool PossuiAlgumaDocumentacaoAnexada()
        {
            if (!string.IsNullOrEmpty(DocumentoDeContrato))
                return true;

            if (!string.IsNullOrEmpty(DocumentoDeNadaConstaDetran))
                return true;

            if (!string.IsNullOrEmpty(DocumentoDeNadaConstaCriminal))
                return true;

            if (!string.IsNullOrEmpty(DocumentoDeCheckListSaida))
                return true;

            if (!string.IsNullOrEmpty(DocumentoDeIdentificacao))
                return true;

            if (!string.IsNullOrEmpty(DocumentoDeComprovanteDeEndereco))
                return true;

            return false;
        }

        public bool PossuiLocacaoPreenchidaCompleta()
        {
            return ValidarCamposLocacao();
        }

        public bool PossuiDocumentacaoPreenchidaCompleta()
        {
            return ValidarDocumentacaoRetirada();
        }

        public bool ValidarCamposDevolucaoLocacao()
        {
            if (DataDeDevolucao == null)
                return false;

            if (string.IsNullOrEmpty(ObservacoesDeChegada))
                return false;

            return true;
        }

        public bool AtualizarLocacao(Locacao model)
        {
            DataRetirada = model.DataRetirada;
            DataPrevistaDeDevolucao = model.DataPrevistaDeDevolucao;
            PrecoCombinado = model.PrecoCombinado;
            QuilometragemAtual = model.QuilometragemAtual;
            ObservacoesDeSaida = model.ObservacoesDeSaida;
            VeiculoId = model.VeiculoId;

            if (model.AcessoriosIds != null && model.AcessoriosIds.Any())
            {
                Acessorios = new List<Acessorio>();

                foreach (var acessorioId in model.AcessoriosIds)
                {                    
                    Acessorios.Add(new Acessorio { Id = acessorioId });
                }
            }

            return ValidarCamposLocacao();
        }

        public bool AtualizarDevolucaoDaLocacao(Locacao model)
        {
            DataDeDevolucao = model.DataDeDevolucao;
            QuilometragemAtual = model.QuilometragemAtual;
            ObservacoesDeChegada = model.ObservacoesDeChegada;
            return ValidarCamposDevolucaoLocacao();
        }

        public void AtualizarCliente(Locacao model)
        {
            Cliente.Atualizar(model.Cliente);
        }

        public void AtualizarContrato(string rota)
        {
            DocumentoDeContrato = rota;
        }

        public void AtualizarNadaConstaDetran(string rota)
        {
            DocumentoDeNadaConstaDetran = rota;
        }

        public void AtualizarNadaConstaCriminal(string rota)
        {
            DocumentoDeNadaConstaCriminal = rota;
        }

        public void AtualizarCheckListSaida(string rota)
        {
            DocumentoDeCheckListSaida = rota;
        }

        public void AtualizarCheckListChegada(string rota)
        {
            DocumentoDeCheckListChegada = rota;
        }

        public void AtualizarDocumentoDeIdentificacao(string rota)
        {
            DocumentoDeIdentificacao = rota;
        }

        public void AtualizarComprovanteDeEndereco(string rota)
        {
            DocumentoDeComprovanteDeEndereco = rota;
        }

        public void SetIds()
        {
            if (Acessorios != null && Acessorios.Any()) 
                AcessoriosIds = Acessorios.Select(x => x.Id).ToArray();
        }

        [Display(Name = "Acessórios")]
        [NotMapped]
        public int[] AcessoriosIds { get; set; }
    }
}