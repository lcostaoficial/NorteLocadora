using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public abstract class Foto
    {
        public int Id { get; set; }

        [Display(Name = "Data de Registro")]
        public DateTime DataDeRegistro { get; set; }

        [Display(Name = "Descrição")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        public string Caminho { get; set; }
    }
}