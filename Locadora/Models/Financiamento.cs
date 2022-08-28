using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Locadora.Models
{
    public class Financiamento
    {
        public int Id { get; set; }

        [Display(Name = "Dt. de Venc. da Primeira Parcela")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataDeVencimentoDaPrimeiraParcela { get; set; }


        [Display(Name = "Quantidade de Parcelas")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int QuantidadeDeParcelas { get; set; }

        public bool Quitado { get; set; }

        [Display(Name = "Valor da Parcela")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal ValorDaParcela { get; set; }
        public bool Ativo { get; set; }

        [Display(Name = "Veículo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public void GerarParcelasDoFinanciamento()
        {
            Parcelas = new List<ParcelaDoFinanciamento>();

            for (int i = 1; i <= QuantidadeDeParcelas; i++)
            {
                Parcelas.Add(new ParcelaDoFinanciamento
                {
                    DataDePagamento = null,
                    DataDeVencimento = DataDeVencimentoDaPrimeiraParcela.AddMonths(i - 1),
                    Paga = false,
                    ValorDaParcela = ValorDaParcela,
                    ValorPago = 0                    
                }); 
            }
        }

        public void Excluir()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public string ParcelasVigentes
        {
            get
            {
                return $"{QuantidadeDeParcelasPagas}/{QuantidadeDeParcelas}";
            }
        }

        public int QuantidadeDeParcelasPagas
        {
            get
            {
                if (Parcelas != null && Parcelas.Any())
                {
                    return Parcelas.Count(x => x.Paga);
                }
                else
                {
                    return 0;
                }
            }
        }

        public ICollection<ParcelaDoFinanciamento> Parcelas { get; set; }
    }
}