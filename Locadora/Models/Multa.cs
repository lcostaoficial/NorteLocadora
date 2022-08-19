using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Multa
    {
        public int Id { get; set; }

        [Display(Name = "Infrator")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NomeInfrator { get; set; }

        [Display(Name = "CPF")]      
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CpfInfrator { get; set; }

        [Display(Name = "Valor da Multa")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal ValorMulta { get; set; }


        [Display(Name = "Data de Vencimento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataDeVencimento { get; set; }


        [Display(Name = "Observações")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Observacoes { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Placa")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int VeiculoId { get; set; }

        public Veiculo Veiculo { get; set; }

        public void Atualizar(Multa novo)
        {
            NomeInfrator = novo.NomeInfrator;
            CpfInfrator = novo.CpfInfrator;
            ValorMulta = novo.ValorMulta;
            DataDeVencimento = novo.DataDeVencimento;
            Observacoes = novo.Observacoes;
            VeiculoId = novo.VeiculoId;
        }

        public void Excluir()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}
