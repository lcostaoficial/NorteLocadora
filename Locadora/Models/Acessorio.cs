using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public class Acessorio
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Display(Name = "Preço de Custo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal PrecoDeCusto { get; set; }

        public bool Ativo { get; set; }

        public ICollection<Locacao> Locacoes { get; set; }

        public void Atualizar(Acessorio novo)
        {
            Descricao = novo.Descricao;
            PrecoDeCusto = novo.PrecoDeCusto;
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