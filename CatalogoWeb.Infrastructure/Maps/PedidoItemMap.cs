using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class PedidoItemMap : IEntityTypeConfiguration<PedidoItem>
{
    public void Configure(EntityTypeBuilder<PedidoItem> builder)
    {
        builder.ToTable("pedidoitem");

        builder.HasKey(pi => pi.pdi_id);
        builder.Property(pi => pi.pdi_quantidade).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_valorunitario).IsRequired().HasPrecision(15, 6);
        builder.Property(pi => pi.pdi_valoracrescimo).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_valordesconto).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_valortotal).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_basecalculoicms).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_percentualicms).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_valoricms).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_basecalculoicmsst).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_percentualicmsst).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_valoricmsst).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_basecalculoipi).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_percentualipi).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_valoripi).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_valorfrete).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_valorseguro).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_valoroutrasdespesas).IsRequired().HasPrecision(15, 3);
        builder.Property(pi => pi.pdi_observacao).HasMaxLength(500);


        builder.HasOne(d => d.pedido)
            .WithMany(p => p.pedidoitens)
            .HasForeignKey(d => d.ped_id);

        builder.HasOne(d => d.produtograde)
            .WithMany(p => p.pedidoitens)
            .HasForeignKey(d => d.prg_id);

        builder.HasOne(d => d.produto)
            .WithMany(p => p.pedidoitens)
            .HasForeignKey(d => d.pro_id);
    }
}