using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class CidadeMap : IEntityTypeConfiguration<Cidade>
{
    public void Configure(EntityTypeBuilder<Cidade> builder)
    {
        builder.ToTable("cidade");
        builder.HasKey(c => c.cid_id);

        builder.Property(c => c.cid_descricao).IsRequired().HasMaxLength(100);
        builder.Property(c => c.cid_numcepinicial).HasMaxLength(8);
        builder.Property(c => c.cid_numcepfinal).HasMaxLength(8);
        builder.Property(c => c.cid_ddd1).HasMaxLength(2);
        builder.Property(c => c.cid_ddd2).HasMaxLength(2);
        builder.Property(c => c.cid_status).IsRequired();

        builder.HasOne(d => d.estado)
              .WithMany(p => p.cidades)
              .HasForeignKey(d => d.est_id);

    }
}