using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class PedidoMap : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("pedido");

        builder.HasKey(p => p.ped_id);
        builder.Property(p => p.ped_numero).IsRequired();
        builder.Property(p => p.ped_datainclusao).IsRequired();
        builder.Property(p => p.ped_observacao).HasMaxLength(800);
        builder.Property(p => p.ped_responsavelpedido).HasMaxLength(50);
        builder.Property(p => p.pes_cidade).HasMaxLength(80).IsRequired();
        builder.Property(p => p.pes_uf).HasMaxLength(2).IsRequired();
        builder.Property(p => p.pes_bairro).HasMaxLength(50).IsRequired();
        builder.Property(p => p.pes_nroestabelecimento).HasMaxLength(10).IsRequired();
        builder.Property(p => p.pes_endereco).HasMaxLength(80).IsRequired();
        builder.Property(p => p.pes_telefone).HasMaxLength(20).IsRequired();


        builder.HasOne(d => d.cliente)
            .WithMany(p => p.pedidos)
            .HasForeignKey(d => d.cli_id);

        builder.HasOne(d => d.local)
            .WithMany(p => p.pedidos)
            .HasForeignKey(d => d.loc_id);

        builder.HasOne(d => d.vendedor)
            .WithMany(p => p.pedidos)
            .HasForeignKey(d => d.ven_id);
    }
}