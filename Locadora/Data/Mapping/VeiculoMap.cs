using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.Mapping
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.Placa).IsRequired().HasMaxLength(250);
            builder.Property(X => X.Marca).IsRequired().HasMaxLength(250);
            builder.Property(X => X.Modelo).IsRequired().HasMaxLength(250);
            builder.Property(X => X.AnoDeFabricacao).IsRequired();
            builder.Property(X => X.AnoDeModelo).IsRequired();
            builder.Property(X => X.Ativo).IsRequired();
            //builder.Property(X => X.CustoDoValorDaDiaria).HasColumnType("decimal(18,2)").IsRequired();
        }
    }
}