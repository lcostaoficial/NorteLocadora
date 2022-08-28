using System;

namespace Locadora.Models
{
    public class Notificacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Icone { get; set; }
        public string Rota { get; set; }
        public DateTime DataDeExibicao { get; set; }
        public bool Lida { get; set; }
        public bool Ativa { get; set; } = true;

        public void LerNotificacao()
        {
            Lida = true;
        }
    }
}