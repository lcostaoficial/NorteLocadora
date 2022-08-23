using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Locadora.Data.Mapping
{
    public class ManutencaoMap : IEntityTypeConfiguration<Manutencao>
    {
        public void Configure(EntityTypeBuilder<Manutencao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.Descricao).IsRequired().HasMaxLength(250);
            builder.Property(X => X.Data).IsRequired();
            builder.Property(X => X.Quilometragem).IsRequired();
            builder.Property(X => X.Valor).IsRequired();
            builder.Property(X => X.Ativo).IsRequired();

            builder.HasOne(x => x.Veiculo).WithMany().HasForeignKey(x => x.VeiculoId).IsRequired(false);
            builder.Property(x => x.TipoManutencao).HasConversion(x => x.ToString(), x => (TipoManutencao)Enum.Parse(typeof(TipoManutencao), x));
        }
    }
}
