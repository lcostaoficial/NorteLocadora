using System;
using System.Collections.Generic;

namespace Locadora.Models
{
    public class Financiamento
    {
        public int Id { get; set; }
        public DateTime DataDeVencimentoDaPrimeiraParcela { get; set; }
        public int QuantidadeDeParcelas { get; set; }
        public bool Quitado { get; set; }
        public bool Ativo { get; set; }

        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public ICollection<ParcelaDoFinanciamento> Parcelas { get; set; }
    }
}