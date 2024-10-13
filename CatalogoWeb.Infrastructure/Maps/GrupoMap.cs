using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class GrupoMap : IEntityTypeConfiguration<Grupo>
{
    public void Configure(EntityTypeBuilder<Grupo> builder)
    {
        builder.ToTable("grupo");

        builder.HasKey(g => g.gru_id);
        builder.Property(g => g.gru_nome).IsRequired().HasMaxLength(80);
        builder.Property(g => g.gru_ativo).IsRequired();
        builder.Property(g => g.emp_id).IsRequired();

        builder.HasOne(d => d.empresa)
            .WithMany(p => p.grupos)
            .HasForeignKey(d => d.emp_id);
    }
}