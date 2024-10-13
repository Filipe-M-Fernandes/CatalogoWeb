using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class GrupoMenuMap : IEntityTypeConfiguration<GrupoMenu>
{
    public void Configure(EntityTypeBuilder<GrupoMenu> builder)
    {
        builder.ToTable("grupomenu");

        builder.HasKey(gm => gm.grm_id);
        builder.Property(gm => gm.grm_descricao).HasMaxLength(100).IsRequired();
    }
}