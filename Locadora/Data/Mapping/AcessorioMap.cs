using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.Mapping
{
    public class AcessorioMap : IEntityTypeConfiguration<Acessorio>
    {
        public void Configure(EntityTypeBuilder<Acessorio> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.Descricao).IsRequired().HasMaxLength(250);
            builder.Property(X => X.PrecoDeCusto).IsRequired().HasMaxLength(250);
            builder.Property(X => X.Ativo).IsRequired();
        }
    }
}