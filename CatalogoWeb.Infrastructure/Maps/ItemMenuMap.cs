using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ItemMenuMap : IEntityTypeConfiguration<ItemMenu>
{
    public void Configure(EntityTypeBuilder<ItemMenu> builder)
    {
        builder.ToTable("itemmenu");

        builder.HasKey(im => im.itm_id);
        builder.Property(im => im.itm_descricao).HasMaxLength(100).IsRequired();
        builder.Property(im => im.itm_rota).HasMaxLength(500).IsRequired();

        builder.HasOne(d => d.grupomenu)
            .WithMany(p => p.itemmenus)
            .HasForeignKey(d => d.grm_id);
    }
}