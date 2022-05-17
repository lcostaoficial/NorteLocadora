using System;

namespace Locadora.Models
{
    public class Locacao
    {
        public int Id { get; set; }

        public DateTime DataRetirada { get; set; }
        public DateTime DataPrevistaDeDevolucao { get; set; }
        public DateTime DataDeDevolucao { get; set; }
        public int QuilometragemAtual { get; set; }
        public int? QuilometragemDeDevolucao { get; set; }
        public decimal PrecoCombinado { get; set; }

        public string DocumentoDeContrato { get; set; }
        public string DocumentoDeNadaConstaDetran { get; set; }
        public string DocumentoDeNadaConstaCriminal { get; set; }
        public string DocumentoDeCheckList { get; set; }
        public string DocumentoDeIdentificacao { get; set; }
        public string DocumentoDeComprovanteDeEndereco { get; set; }

        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public bool Devolvido { get; set; }
    }
}
