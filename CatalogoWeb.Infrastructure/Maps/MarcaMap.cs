using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class MarcaMap : IEntityTypeConfiguration<Marca>
{
    public void Configure(EntityTypeBuilder<Marca> builder)
    {
        builder.ToTable("marca");

        builder.HasKey(m => m.mar_id);
        builder.Property(m => m.mar_nome).HasMaxLength(50);
        builder.Property(m => m.mar_ativa).IsRequired();

        builder.HasOne(d => d.empresa)
            .WithMany(p => p.marcas)
            .HasForeignKey(d => d.emp_id);
    }
}