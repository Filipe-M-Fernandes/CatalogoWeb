using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ProdutoEstoqueMap : IEntityTypeConfiguration<ProdutoEstoque>
{
    public void Configure(EntityTypeBuilder<ProdutoEstoque> builder)
    {
        builder.ToTable("produtoestoque");

        builder.HasKey(p => p.pre_id);
        builder.Property(p => p.pre_tiporegistro).IsRequired();
        builder.Property(p => p.pre_qtde).HasPrecision(16, 3).IsRequired();
        builder.Property(p => p.pre_valorcustomedio).HasPrecision(16, 6);
        builder.Property(p => p.pre_custoultimacompra).HasPrecision(16, 6);

        builder.HasOne(d => d.local)
            .WithMany(p => p.produtoestoques)
            .HasForeignKey(d => d.loc_id);

        builder.HasOne(d => d.produtograde)
            .WithMany(p => p.produtoestoques)
            .HasForeignKey(d => d.prg_id);

        builder.HasOne(d => d.produto)
            .WithMany(p => p.produtoestoques)
            .HasForeignKey(d => d.pro_id);
    }
}