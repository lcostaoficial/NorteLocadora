using System;

namespace Locadora.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Descricao { get; set; } 
        public DateTime DataDeVencimento { get; set; } 
        public DateTime? DataDePagamento { get; set; } 
        public string DocumentoDeComprovante { get; set; }
        public decimal Valor { get; set; }

        public int? VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}