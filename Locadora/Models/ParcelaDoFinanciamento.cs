using System;

namespace Locadora.Models
{
    public class ParcelaDoFinanciamento
    {
        public int Id { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public DateTime? DataDePagamento { get; set; }
        public decimal ValorDaParcela { get; set; }
        public decimal ValorPago { get; set; }
        public bool Paga { get; set; }

        public int FinanciamentoId { get; set; }
        public Financiamento Financiamento { get; set; }
    }
}