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
            builder.Property(X => X.DataRetirada).IsRequired(false);
            builder.Property(X => X.DataPrevistaDeDevolucao).IsRequired(false);
            builder.Property(X => X.DataDeDevolucao).IsRequired(false);
            builder.Property(X => X.QuilometragemAtual).IsRequired(false);
            builder.Property(X => X.QuilometragemDeDevolucao).IsRequired(false);
            builder.Property(X => X.DocumentoDeContrato).IsRequired(false);
            builder.Property(X => X.DocumentoDeNadaConstaDetran).IsRequired(false);
            builder.Property(X => X.DocumentoDeNadaConstaCriminal).IsRequired(false);
            builder.Property(X => X.DocumentoDeCheckListSaida).IsRequired(false);
            builder.Property(X => X.DocumentoDeCheckListChegada).IsRequired(false);
            builder.Property(X => X.ObservacoesDeSaida).IsRequired(false);
            builder.Property(X => X.ObservacoesDeChegada).IsRequired(false);
            builder.Property(X => X.DocumentoDeIdentificacao).IsRequired(false);
            builder.Property(X => X.DocumentoDeComprovanteDeEndereco).IsRequired(false);
            builder.Property(X => X.Finalizada).IsRequired();
            builder.Property(X => X.Devolvido).IsRequired();

            builder.HasOne(x => x.Veiculo).WithMany(x => x.Locacoes).HasForeignKey(x => x.VeiculoId).IsRequired(false);
            builder.HasOne(x => x.Cliente).WithMany(x => x.Locacoes).HasForeignKey(x => x.ClienteId).IsRequired(true);
        }
    }
}