using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.Mapping
{
    public class LocacaoMap : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.DataRetirada).IsRequired();
            builder.Property(X => X.DataPrevistaDeDevolucao).IsRequired();
            builder.Property(X => X.DataDeDevolucao).IsRequired();
            builder.Property(X => X.QuilometragemAtual).IsRequired();
            builder.Property(X => X.QuilometragemDeDevolucao).IsRequired(false);
            //builder.Property(X => X.PrecoCombinado).IsRequired();
            builder.Property(X => X.DocumentoDeContrato).IsRequired();
            builder.Property(X => X.DocumentoDeNadaConstaDetran).IsRequired();
            builder.Property(X => X.DocumentoDeNadaConstaCriminal).IsRequired();
            builder.Property(X => X.DocumentoDeCheckList).IsRequired();
            builder.Property(X => X.DocumentoDeIdentificacao).IsRequired();
            builder.Property(X => X.DocumentoDeComprovanteDeEndereco).IsRequired();
            builder.Property(X => X.Devolvido).IsRequired();

            builder.HasOne(x => x.Veiculo).WithMany().HasForeignKey(x => x.VeiculoId).IsRequired(false);
            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.ClienteId).IsRequired(false);
        }
    }
}