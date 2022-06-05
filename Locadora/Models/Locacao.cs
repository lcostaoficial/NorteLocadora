using System;
using System.ComponentModel.DataAnnotations;

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

        public string DocumentoDeContrato { get; set; }
        public string DocumentoDeNadaConstaDetran { get; set; }
        public string DocumentoDeNadaConstaCriminal { get; set; }
        public string DocumentoDeCheckList { get; set; }
        public string DocumentoDeIdentificacao { get; set; }
        public string DocumentoDeComprovanteDeEndereco { get; set; }

        public int? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public bool Devolvido { get; set; }

        public bool AtualizarLocacao(Locacao model)
        {
            DataRetirada = model.DataRetirada;
            DataPrevistaDeDevolucao = model.DataPrevistaDeDevolucao;
            PrecoCombinado = model.PrecoCombinado;
            QuilometragemAtual = model.QuilometragemAtual;
            VeiculoId = model.VeiculoId;

            bool ValidarCampos()
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

            return ValidarCampos();
        }

        public void AtualizarCliente(Locacao model)
        {
            Cliente.Atualizar(model.Cliente);
        }
    }
}
