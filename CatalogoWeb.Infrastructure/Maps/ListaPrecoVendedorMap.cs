using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ListaPrecoVendedorMap : IEntityTypeConfiguration<ListaPrecoVendedor>
{
    public void Configure(EntityTypeBuilder<ListaPrecoVendedor> builder)
    {
        builder.ToTable("listapreco_vendedor");
        builder.HasKey(ul => new { ul.ltp_id, ul.ven_id });

        builder.Property(p => p.ltp_id)
            .HasColumnName("ltp_id")
            .IsRequired();

        builder.Property(p => p.ven_id)
            .HasColumnName("ven_id")
            .IsRequired();

        builder.HasOne(ul => ul.listaPreco)
            .WithMany(u => u.listaprecovendedores)
            .HasForeignKey(ul => ul.ltp_id);

        builder.HasOne(ul => ul.vendedor)
            .WithMany(u => u.listaprecovendedores)
            .HasForeignKey(ul => ul.ven_id);
    }
}
