using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public DateTime? DataDeDevolucao { get; set; }

        [Display(Name = "KM de Saída")]
        public int? QuilometragemAtual { get; set; }

        public int? QuilometragemDeDevolucao { get; set; }

        [Display(Name = "Observações de saída")]
        public string ObservacoesDeSaida { get; set; }

        [Display(Name = "Observações de chegada")]
        public string ObservacoesDeChegada { get; set; }

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

        public bool ValidarCampos()
        {
            if (DataRetirada == null)
                return false;

            if (DataPrevistaDeDevolucao == null)
                return false;

            if (PrecoCombinado == null)
                return false;

            if (QuilometragemAtual == null)
                return false;

            if (VeiculoId == null || VeiculoId == 0)
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
            return ValidarCampos();
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
    }
}
