using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class PaisMap : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("pais");

        builder.HasKey(p => p.pse_id);
        builder.Property(p => p.pse_nome).IsRequired();
        builder.Property(p => p.pse_sigla).IsRequired().HasMaxLength(2);
        builder.Property(p => p.pse_siglaiso).HasMaxLength(3);
        builder.Property(p => p.pse_formatocep).HasMaxLength(30);
        builder.Property(p => p.pse_status).IsRequired();
        builder.Property(p => p.pse_codigobacen).HasMaxLength(4);

    }
}