using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.Mapping
{
    public class DespesaMap : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.Descricao).IsRequired().HasMaxLength(250);
            builder.Property(X => X.DataDeVencimento).IsRequired();
            builder.Property(X => X.DataDePagamento).IsRequired(false);
            builder.Property(X => X.DocumentoDeComprovante).IsRequired(false);
            builder.Property(X => X.Valor).IsRequired();

            builder.HasOne(x => x.Veiculo).WithMany().HasForeignKey(x => x.VeiculoId).IsRequired(false);
        }
    }
}
