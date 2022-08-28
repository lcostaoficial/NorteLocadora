using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.Mapping
{
    public class MultaMap : IEntityTypeConfiguration<Multa>
    {
        public void Configure(EntityTypeBuilder<Multa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.NomeInfrator).IsRequired().HasMaxLength(250);
            builder.Property(X => X.CpfInfrator).IsRequired().HasMaxLength(14);
            builder.Property(X => X.ValorMulta).IsRequired();
            builder.Property(X => X.DataDeVencimento).IsRequired();
            builder.Property(X => X.Observacoes).HasMaxLength(8000).IsRequired();
            builder.Property(X => X.Ativo).IsRequired();

            builder.HasOne(x => x.Veiculo).WithMany().HasForeignKey(x => x.VeiculoId).IsRequired();
        }
    }
}
