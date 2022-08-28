using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.Mapping
{
    public class ParcelaDoFinanciamentoMap : IEntityTypeConfiguration<ParcelaDoFinanciamento>
    {
        public void Configure(EntityTypeBuilder<ParcelaDoFinanciamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.DataDeVencimento).IsRequired();
            builder.Property(X => X.DataDePagamento).IsRequired(false);
            builder.Property(X => X.ValorDaParcela).IsRequired();
            builder.Property(X => X.ValorPago).IsRequired();
            builder.Property(X => X.Paga).IsRequired();

            builder.HasOne(x => x.Financiamento).WithMany(x => x.Parcelas).HasForeignKey(x => x.FinanciamentoId).IsRequired();
        }
    }
}