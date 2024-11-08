using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ProdutoUnidadeMap : IEntityTypeConfiguration<ProdutoUnidade>
{
    public void Configure(EntityTypeBuilder<ProdutoUnidade> builder)
    {
        builder.ToTable("produtounidade");

        builder.HasKey(p => p.pru_id);
        builder.Property(p => p.ump_id).HasMaxLength(10);
        builder.Property(p => p.pru_quantidade).IsRequired();
        builder.Property(p => p.pru_qtdeunidadepadrao).IsRequired();

        builder.HasOne(d => d.produto)
            .WithMany(p => p.produtounidades)
            .HasForeignKey(d => d.pro_id);

        builder.HasOne(d => d.unidademedida)
            .WithMany(p => p.produtounidades)
            .HasForeignKey(d => d.ump_id);
    }
}