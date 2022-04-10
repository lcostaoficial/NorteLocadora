using System.Collections.Generic;

namespace Locadora.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int AnoDeModelo { get; set; }
        public int AnoDeFabricacao { get; set; }

        public ICollection<FotoDeGaragem> FotosDeGaragem { get; set; }
    }
}