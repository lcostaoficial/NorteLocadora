using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Manutencao
    {
        public int Id { get; set; }
        public TipoManutencao TipoManutencao { get; set; }
        public DateTime Data { get; set; }

        [Display(Name = "Descrição")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Quilometragem { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal Valor { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Veículo")]
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public void Atualizar(Manutencao novo)
        {
            Descricao = novo.Descricao;
            Quilometragem = novo.Quilometragem;
            Valor = novo.Valor;          
            VeiculoId = novo.VeiculoId;
            Data = novo.Data;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Excluir()
        {
            Ativo = false;
        }

        public void ConfigurarComoPreventiva()
        {
            TipoManutencao = TipoManutencao.Preventiva;
        }

        public void ConfigurarComoCorretiva()
        {
            TipoManutencao = TipoManutencao.Corretiva;
        }
    }
}