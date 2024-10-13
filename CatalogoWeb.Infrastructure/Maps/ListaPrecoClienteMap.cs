using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps
{
    public class ListaPrecoClienteMap : IEntityTypeConfiguration<ListaPrecoCliente>
    {
        public void Configure(EntityTypeBuilder<ListaPrecoCliente> builder)
        {
            builder.ToTable("listapreco_cliente");
            builder.HasKey(ul => new {ul.ltp_id, ul.cli_id});

            builder.Property(p => p.ltp_id)
                .HasColumnName("ltp_id")
                .IsRequired();

            builder.Property(p => p.cli_id)
                .HasColumnName("cli_id")
                .IsRequired();

            builder.HasOne(ul => ul.listaPreco)
                .WithMany(u => u.listaprecoclientes)
                .HasForeignKey(ul => ul.ltp_id);
        }
    }
}
