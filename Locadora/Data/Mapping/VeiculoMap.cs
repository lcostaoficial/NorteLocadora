using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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
            builder.Property(X => X.Cor).IsRequired();
            builder.Property(X => X.Renavam).IsRequired();
            builder.Property(X => X.Ativo).IsRequired();

            builder.Property(x => x.TipoDeVeiculo).HasConversion(x => x.ToString(), x => (TipoDeVeiculo)Enum.Parse(typeof(TipoDeVeiculo), x));
        }
    }
}