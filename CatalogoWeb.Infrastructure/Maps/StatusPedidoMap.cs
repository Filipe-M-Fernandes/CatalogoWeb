using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class StatusPedidoMap : IEntityTypeConfiguration<StatusPedido>
{
    public void Configure(EntityTypeBuilder<StatusPedido> builder)
    {
        builder.ToTable("statuspedido");

        builder.HasKey(sp => sp.stp_id);
        builder.Property(sp => sp.stp_descricao).IsRequired().HasMaxLength(40);
        builder.Property(sp => sp.stp_ativo).IsRequired();

        builder.HasOne(d => d.empresa)
                .WithMany(p => p.statuspedidos)
                .HasForeignKey(d => d.emp_id);

    }
}