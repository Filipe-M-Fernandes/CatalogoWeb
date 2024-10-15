using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class LocalMap : IEntityTypeConfiguration<Local>
{
    public void Configure(EntityTypeBuilder<Local> builder)
    {
        builder.ToTable("local");

        builder.HasKey(l => l.loc_id);

        builder.Property(l => l.loc_codigo).IsRequired().HasMaxLength(20);
        builder.Property(l => l.loc_descricao).IsRequired().HasMaxLength(100);
        builder.Property(l => l.loc_numeroestabelecimento).IsRequired();
        builder.Property(l => l.loc_substitutotributario).IsRequired();
        builder.Property(l => l.loc_ativo).IsRequired();
        builder.Property(l => l.loc_datainclusao).IsRequired();
        builder.Property(l => l.loc_matriz).IsRequired();
        builder.Property(l => l.loc_nomefantasia).HasMaxLength(120);

         builder.HasOne(d => d.empresa)
            .WithMany(p => p.locais)
            .HasForeignKey(d => d.emp_id);

        builder.HasOne(d => d.logradouroCidade)
            .WithMany(p => p.locais)
            .HasForeignKey(d => d.lcd_id);

        builder.HasOne(p => p.parametrolocal)
            .WithOne(d => d.local)
            .HasForeignKey<ParametrosLocal>(d => d.loc_id);

     
    }
}