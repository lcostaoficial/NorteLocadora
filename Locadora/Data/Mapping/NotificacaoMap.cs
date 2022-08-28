using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Data.Mapping
{
    public class NotificacaoMap : IEntityTypeConfiguration<Notificacao>
    {
        public void Configure(EntityTypeBuilder<Notificacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(X => X.Descricao).IsRequired().HasMaxLength(250);
            builder.Property(X => X.Icone).IsRequired().HasMaxLength(250);
            builder.Property(X => X.Rota).IsRequired().HasMaxLength(8000);
            builder.Property(X => X.DataDeExibicao).IsRequired();
            builder.Property(X => X.Lida).IsRequired();
            builder.Property(X => X.Ativa).IsRequired();
        }
    }
}