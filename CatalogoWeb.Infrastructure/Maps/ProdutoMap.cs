 using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("produto");
        builder.HasKey(e => e.pro_id);

        builder.Property(e => e.pro_descricao).HasMaxLength(120);
        builder.Property(e => e.pro_ean).HasMaxLength(20);
        builder.Property(e => e.pro_observacao).HasMaxLength(500);
        builder.Property(e => e.pro_referencia).HasMaxLength(50);
        builder.Property(e => e.ump_id).IsRequired().HasMaxLength(10);
        builder.Property(e => e.pro_pesobruto).HasPrecision(18, 4);
        builder.Property(e => e.pro_pesoliquido).HasPrecision(18, 4);

        builder.HasOne(d => d.empresa)
            .WithMany(p => p.produtos)
            .HasForeignKey(d => d.emp_id);
        
        builder.HasOne(d => d.grupo)
            .WithMany(p => p.produtos)
            .HasForeignKey(d => d.gru_id);
        
        builder.HasOne(d => d.marca)
            .WithMany(p => p.produtos)
            .HasForeignKey(d => d.mar_id);
        
        builder.HasOne(d => d.ncm)
            .WithMany(p => p.produtos)
            .HasForeignKey(d => d.ncm_id);

        builder.HasOne(d => d.subgrupo)
            .WithMany(p => p.produtos)
            .HasForeignKey(d => d.sgp_id);
        
        builder.HasOne(d => d.unidademedida)
            .WithMany(p => p.produtos)
            .HasForeignKey(d => d.ump_id);

    }
}