using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps
{
    public class GruposAcessoMap : IEntityTypeConfiguration<GruposAcesso>
    {
        public void Configure(EntityTypeBuilder<GruposAcesso> builder)
        {
            builder.ToTable("gruposacesso");
            builder.HasKey(p => p.gac_id);
        }
    }
}
