namespace Locadora.Models
{
    public class FotoDeGaragem : Foto
    {
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}