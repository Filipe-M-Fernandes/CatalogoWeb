using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ListaPrecoItemMap : IEntityTypeConfiguration<ListaPrecoItem>
{
    public void Configure(EntityTypeBuilder<ListaPrecoItem> builder)
    {
        builder.ToTable("listaprecoitem");
        builder.HasKey(l => l.lpi_id);
        builder.Property(l => l.lpi_valorvenda).IsRequired().HasPrecision(16, 3);
        builder.Property(l => l.lpi_naocalculacomissao).IsRequired();

        builder.HasOne(d => d.listapreco)
            .WithMany(p => p.listaprecoitens)
            .HasForeignKey(d => d.ltp_id);

        builder.HasOne(d => d.produtograde)
            .WithMany(p => p.listaprecoitens)
            .HasForeignKey(d => d.prg_id);

        builder.HasOne(d => d.produto)
            .WithMany(p => p.listaprecoitens)
            .HasForeignKey(d => d.pro_id);
            
    }
}