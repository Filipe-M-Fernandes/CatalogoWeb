using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class NcmMap : IEntityTypeConfiguration<Ncm>
{
    public void Configure(EntityTypeBuilder<Ncm> builder)
    {

        builder.ToTable("ncm");

        builder.HasKey(n => n.ncm_id);
        builder.Property(n => n.cip_entrada).HasMaxLength(5);
        builder.Property(n => n.cip_saida).HasMaxLength(5);
        builder.Property(n => n.ncm_extipi).HasMaxLength(2);
        builder.Property(n => n.ncm_descricao).IsRequired().HasMaxLength(500);
        builder.Property(n => n.ncm_percentual);

        builder.HasOne(d => d.empresa)
            .WithMany(p => p.ncms)
            .HasForeignKey(d => d.emp_id);
    }
}