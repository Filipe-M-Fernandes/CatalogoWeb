using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class UnidadeMedidaMap : IEntityTypeConfiguration<UnidadeMedida>
{
    public void Configure(EntityTypeBuilder<UnidadeMedida> builder)
    {
        builder.ToTable("unidademedida");

        builder.HasKey(u => u.ump_id);
        builder.Property(u => u.ump_id).HasMaxLength(10);
        builder.Property(u => u.ump_descricao).IsRequired().HasMaxLength(100);
        builder.Property(u => u.ump_casasdecimais).IsRequired();
    }
}