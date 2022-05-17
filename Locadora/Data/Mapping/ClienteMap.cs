using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Locadora.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.EstadoCivil).HasConversion(x => x.ToString(), x => (EstadoCivil)Enum.Parse(typeof(EstadoCivil), x));
            builder.Property(x => x.OrgaoExpedidorRg).HasConversion(x => x.ToString(), x => (OrgaoExpedidorRg)Enum.Parse(typeof(OrgaoExpedidorRg), x));
            builder.Property(x => x.Estado).HasConversion(x => x.ToString(), x => (Estado)Enum.Parse(typeof(Estado), x));
        }
    }
}