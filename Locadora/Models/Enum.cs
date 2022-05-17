using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Models
{
    public enum TipoDeVeiculo
    {
        Carro = 1,
        Moto = 2
    }   

    public enum Perfil
    {
        Administrador = 1,
        Funcionario = 2
    }

    public enum EstadoCivil
    {
        Solteiro = 1,
        Casado = 2,
        Separado = 3,
        Divorciado = 4,
        Viuvo = 5
    }

    public enum OrgaoExpedidorRg
    {
        [Display(Name = "Secretaria de Segurança Pública")]
        [Description("Secretaria de Segurança Pública")]
        SSP = 1,

        [Display(Name = "Polícia Civil")]
        [Description("Polícia Civil")]
        PC = 2
    }

    public enum Estado
    {
        AC = 1,
        AL = 2,
        AP = 3,
        AM = 4,
        BA = 5,
        CE = 6,
        DF = 7,
        ES = 8,
        GO = 9,
        MA = 10,
        MT = 11,
        MS = 12,
        MG = 13,
        PA = 14,
        PB = 15,
        PR = 16,
        PE = 17,
        PI = 18,
        RJ = 19,
        RN = 20,
        RS = 21,
        RO = 22,
        RR = 23,
        SC = 24,
        SP = 25,
        SE = 26,
        TO = 27
    }
}