using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Locadora.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Display(Name = "Nome")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "Nome da mãe")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NomeMae { get; set; }

        [Display(Name = "CEP")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cep { get; set; }

        [Display(Name = "Rua")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Rua { get; set; }

        [Display(Name = "Número")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(10, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Numero { get; set; }

        [Display(Name = "Bairro")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cidade { get; set; }

        [Display(Name = "Unidade federal")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo obrigatório")]
        [EnumDataType(typeof(Estado), ErrorMessage = "Campo obrigatório")]
        public Estado Estado { get; set; }

        [Display(Name = "Naturalidade")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Naturalidade { get; set; }

        [Display(Name = "Nacionalidade")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nacionalidade { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "UF de nascimento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo obrigatório")]
        [EnumDataType(typeof(Estado), ErrorMessage = "Campo obrigatório")]
        public Estado EstadoNascimento { get; set; }

        [Display(Name = "Profissão")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Profissao { get; set; }

        [Display(Name = "RG")]
        public string Rg { get; set; }

        [Display(Name = "Orgão expedidor do RG")]
        public OrgaoExpedidorRg OrgaoExpedidorRg { get; set; }

        [Display(Name = "Estado emissor do RG")]
        public Estado EstadoOrgaoExpedidor { get; set; }

        [Display(Name = "CPF")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(14, ErrorMessage = "Máximo 14 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cpf { get; set; }

        [Display(Name = "CNH")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cnh { get; set; }

        [Display(Name = "Data de Venc. CNH")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataDeVencimentoDaCnh{ get; set; }

        [Display(Name = "Cat. A")]
        public bool CategoriaCnhA { get; set; }

        [Display(Name = "Cat. B")]
        public bool CategoriaCnhB { get; set; }

        [Display(Name = "Cat. C")]
        public bool CategoriaCnhC { get; set; }

        [Display(Name = "Cat. D")]
        public bool CategoriaCnhD { get; set; }

        [Display(Name = "Cat. E")]
        public bool CategoriaCnhE { get; set; }

        [Display(Name = "Telefone fixo")]
        [MinLength(14, ErrorMessage = "Mínimo 14 caractere")]
        [MaxLength(14, ErrorMessage = "Máximo 14 caracteres")]
        public string TelefoneFixo { get; set; }

        [Display(Name = "Telefone móvel")]
        [MinLength(15, ErrorMessage = "Mínimo 15 caractere")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string TelefoneMovel { get; set; }

        [Display(Name = "Telefone móvel 1")]
        [MinLength(15, ErrorMessage = "Mínimo 15 caractere")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string TelefoneMovel1 { get; set; }

        [Display(Name = "Telefone móvel 2")]
        [MinLength(15, ErrorMessage = "Mínimo 15 caractere")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string TelefoneMovel2 { get; set; }

        [Display(Name = "Telefone móvel 3")]
        [MinLength(15, ErrorMessage = "Mínimo 15 caractere")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string TelefoneMovel3 { get; set; }

        [Display(Name = "E-mail")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }

        [Display(Name = "Estado civil")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo obrigatório")]
        [EnumDataType(typeof(EstadoCivil), ErrorMessage = "Campo obrigatório")]
        public EstadoCivil EstadoCivil { get; set; }

        [Display(Name = "Cliente estrangeiro?")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool ClienteEstrangeiro { get; set; }

        [Display(Name = "Documento do estrangeiro")]
        public string DocumentoIdentificacaoEstrangeiro { get; set; }

        public bool Ativo { get; set; } = true;

        [NotMapped]
        [Display(Name = "Cat. CNH")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public CategoriaHabilitacao[] CatCnh { get; set; }

        [NotMapped]
        public string ImageBase64String { get; set; }

        public void ProcessarCategoriaDaCnh(CategoriaHabilitacao[] catCnh)
        {
            if (catCnh != null && catCnh.Any())
            {
                CategoriaCnhA = false;
                CategoriaCnhB = false;
                CategoriaCnhC = false;
                CategoriaCnhD = false;
                CategoriaCnhE = false;

                foreach (var item in catCnh)
                {
                    if (item.ToString() == "a")
                        CategoriaCnhA = true;

                    if (item.ToString() == "b")
                        CategoriaCnhB = true;

                    if (item.ToString() == "c")
                        CategoriaCnhC = true;

                    if (item.ToString() == "d")
                        CategoriaCnhD = true;

                    if (item.ToString() == "e")
                        CategoriaCnhE = true;
                }
            }
        }

        public void ProcessarCategoriaDaCnh()
        {
            if (CatCnh != null && CatCnh.Any())
            {
                CategoriaCnhA = false;
                CategoriaCnhB = false;
                CategoriaCnhC = false;
                CategoriaCnhD = false;
                CategoriaCnhE = false;

                foreach (var item in CatCnh)
                {
                    if (item.ToString() == "a")
                        CategoriaCnhA = true;

                    if (item.ToString() == "b")
                        CategoriaCnhB = true;

                    if (item.ToString() == "c")
                        CategoriaCnhC = true;

                    if (item.ToString() == "d")
                        CategoriaCnhD = true;

                    if (item.ToString() == "e")
                        CategoriaCnhE = true;
                }
            }
        }

        public void CarrregarCategoriaDaCnh()
        {
            var list = new List<CategoriaHabilitacao>();

            if (CategoriaCnhA)
                list.Add(CategoriaHabilitacao.a);

            if (CategoriaCnhB)
                list.Add(CategoriaHabilitacao.b);

            if (CategoriaCnhC)
                list.Add(CategoriaHabilitacao.c);

            if (CategoriaCnhD)
                list.Add(CategoriaHabilitacao.d);

            if (CategoriaCnhE)
                list.Add(CategoriaHabilitacao.e);

            CatCnh = list.ToArray();
        }

        public void AlterarAtivo()
        {
            Ativo = !Ativo;
        }

        public string EstadoCivilFormatado => EstadoCivil.ToString();
        public string EstadoFormatado => Estado.ToString();
        public string EstadoNascimentoFormatado => EstadoNascimento.ToString();
        public string OrgaoExpedidorRgFormatado => OrgaoExpedidorRg.ToString();
        public string EstadoOrgaoExpedidorFormatado => EstadoOrgaoExpedidor.ToString();
        public string DataNascimentoFormatado => DataNascimento.ToString("dd/MM/yyyy");
        public string DataDeVencimentoDaCnhFormatado => DataDeVencimentoDaCnh.ToString("dd/MM/yyyy");
        public string PortadorDocumento => ClienteEstrangeiro ? $"portador do documento de identificação {DocumentoIdentificacaoEstrangeiro}" : $"portador do RG {Rg} {OrgaoExpedidorRgFormatado}/{EstadoOrgaoExpedidor}";

        [NotMapped]
        public ICollection<Locacao> Locacoes { get; set; }

        public void Atualizar(Cliente model)
        {
            Nome = model.Nome;
            NomeMae = model.NomeMae;
            Rua = model.Rua;
            Numero = model.Numero;
            Bairro = model.Bairro;
            Cidade = model.Cidade;
            Estado = model.Estado;
            Naturalidade = model.Naturalidade;
            Nacionalidade = model.Nacionalidade;
            DataNascimento = model.DataNascimento;
            Profissao = model.Profissao;
            ClienteEstrangeiro = model.ClienteEstrangeiro;
            TelefoneMovel = model.TelefoneMovel;
            TelefoneFixo = model.TelefoneFixo;
            TelefoneMovel1 = model.TelefoneMovel1;
            TelefoneMovel2 = model.TelefoneMovel2;
            TelefoneMovel3 = model.TelefoneMovel3;
            Email = model.Email;
            EstadoCivil = model.EstadoCivil;
            CategoriaCnhA = model.CategoriaCnhA;
            CategoriaCnhB = model.CategoriaCnhB;
            CategoriaCnhC = model.CategoriaCnhC;
            CategoriaCnhD = model.CategoriaCnhD;
            CategoriaCnhE = model.CategoriaCnhE;
            SetEstrangeiro(model);
        }

        public void SetEstrangeiro(Cliente model)
        {
            if (model.ClienteEstrangeiro == false)
            {
                Rg = model.Rg;
                OrgaoExpedidorRg = model.OrgaoExpedidorRg;
                EstadoOrgaoExpedidor = model.EstadoOrgaoExpedidor;
                DocumentoIdentificacaoEstrangeiro = "";
            }
            else
            {
                Rg = string.Empty;
                OrgaoExpedidorRg = 0;
                EstadoOrgaoExpedidor = 0;
                DocumentoIdentificacaoEstrangeiro = model.DocumentoIdentificacaoEstrangeiro;
            }
        }

        public bool ValidarCpf()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            var cpf = Cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
