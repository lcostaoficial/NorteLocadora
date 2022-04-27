using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.Mapping
{
    public class CategoriaDoVeiculoMap : IEntityTypeConfiguration<CategoriaDoVeiculo>
    {
        public void Configure(EntityTypeBuilder<CategoriaDoVeiculo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.Nome).IsRequired().HasMaxLength(250);
            builder.Property(X => X.CustoDoValorDaDiaria).HasColumnType("decimal(18,2)").IsRequired();
        }
    }
}