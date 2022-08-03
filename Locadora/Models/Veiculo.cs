using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Locadora.Models
{
    public class Veiculo
    {
        public Veiculo()
        {
            Ativar();
        }

        public int Id { get; set; }

        [Display(Name = "Marca")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Marca { get; set; }


        [Display(Name = "Modelo")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Modelo { get; set; }

        [Display(Name = "Tipo de Veículo")]
        public TipoDeVeiculo TipoDeVeiculo { get; set; }

        [Display(Name = "Placa")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Placa { get; set; }

        [Display(Name = "Cor")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cor { get; set; }

        [Display(Name = "Renavam")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Renavam { get; set; }

        [Display(Name = "Ano de modelo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int AnoDeModelo { get; set; }

        [Display(Name = "Ano de fabricação")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int AnoDeFabricacao { get; set; }

        [Display(Name = "Quilometragem")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Quilometragem { get; set; }

        public bool Ativo { get; set; }

        public void AtualizarQuilometragem(int quilometragemAtual)
        {
            Quilometragem = quilometragemAtual;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Excluir()
        {
            Ativo = false;
        }

        public void Atualizar(Veiculo model)
        {
            Marca = model.Marca;
            Modelo = model.Modelo;
            Placa = model.Placa;
            AnoDeModelo = model.AnoDeModelo;
            AnoDeFabricacao = model.AnoDeFabricacao;
            Quilometragem = model.Quilometragem;
        }

        public ICollection<FotoDeGaragem> FotosDeGaragem { get; set; }

        public string FotoPrincipal
        {
            get
            {
                if (FotosDeGaragem != null && FotosDeGaragem.Any())
                {
                    return FotosDeGaragem.FirstOrDefault(x => x.Principal).CaminhoVirtual;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        [NotMapped]
        public ICollection<Locacao> Locacoes { get; set; }
    }
}