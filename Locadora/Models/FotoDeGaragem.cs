namespace Locadora.Models
{
    public class FotoDeGaragem : Foto
    {
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public bool Principal { get; set; }
        public bool Ativo { get; set; }

        public string CaminhoVirtual => $"~/Uploads/Fotos/{Caminho}";

        public void TornarFotoNaoPrincipal()
        {
            Principal = false;
        }

        public void Inativar()
        {
            Ativo = false;
        }
    }
}