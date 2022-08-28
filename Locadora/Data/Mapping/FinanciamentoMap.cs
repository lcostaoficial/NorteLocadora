using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.Mapping
{
    public class FinanciamentoMap : IEntityTypeConfiguration<Financiamento>
    {
        public void Configure(EntityTypeBuilder<Financiamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.DataDeVencimentoDaPrimeiraParcela).IsRequired();
            builder.Property(X => X.QuantidadeDeParcelas).IsRequired();
            builder.Property(X => X.Quitado).IsRequired();
            builder.Property(X => X.Ativo).IsRequired();
    
            builder.HasOne(x => x.Veiculo).WithMany().HasForeignKey(x => x.VeiculoId).IsRequired();
        }
    }
}