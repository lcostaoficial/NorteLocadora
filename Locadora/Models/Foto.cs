using System;

namespace Locadora.Models
{
    public abstract class Foto
    {
        public int Id { get; set; }
        public DateTime DataDeRegistro { get; set; }
        public string Descricao { get; set; }
        public string Caminho { get; set; }
    }
}