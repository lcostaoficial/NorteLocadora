using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class CategoriaDoVeiculo
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }
        public decimal CustoDoValorDaDiaria { get; set; }
    }
}