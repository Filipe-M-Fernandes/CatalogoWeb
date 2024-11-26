using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ProdutoGradeMap : IEntityTypeConfiguration<ProdutoGrade>
{
    public void Configure(EntityTypeBuilder<ProdutoGrade> builder)
    {
        builder.ToTable("produtograde");

        builder.HasKey(pg => pg.prg_id);
        builder.Property(p => p.pro_id).IsRequired();
        builder.Property(pg => pg.prg_ean).HasMaxLength(20).IsRequired();

        builder.HasOne(d => d.produto)
            .WithMany(p => p.produtogrades)
            .HasForeignKey(d => d.pro_id);

    }
}