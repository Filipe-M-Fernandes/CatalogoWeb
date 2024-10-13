using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class SubGrupoMap : IEntityTypeConfiguration<SubGrupo>
{
    public void Configure(EntityTypeBuilder<SubGrupo> builder)
    {
        builder.ToTable("subgrupo");

        builder.HasKey(s => s.sgp_id);
        builder.Property(s => s.sgp_nome).IsRequired().HasMaxLength(80);
        builder.Property(s => s.sgp_ativo).IsRequired();

        builder.HasOne(d => d.grupo)
                .WithMany(p => p.subgrupos)
                .HasForeignKey(d => d.gru_id);
    }
}