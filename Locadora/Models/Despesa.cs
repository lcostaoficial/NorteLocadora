using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Despesa
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Data de Vencimento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataDeVencimento { get; set; } 

        public DateTime? DataDePagamento { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal Valor { get; set; }

        public bool Ativa { get; set; }

        public void Atualizar(Despesa model)
        {
            Descricao = model.Descricao;
            DataDeVencimento = model.DataDeVencimento;
            Valor = model.Valor;
        }

        public void Ativar()
        {
            Ativa = true;
        }

        public void Excluir()
        {
            Ativa = false;
        }

        [Display(Name = "Veículo")]  
        public int? VeiculoId { get; set; }

        public Veiculo Veiculo { get; set; }
    }
}