using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ClienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");

        builder.HasKey(c => c.cli_id);
        builder.Property(c => c.cli_codigo).IsRequired();
        builder.Property(c => c.cli_observacao).HasMaxLength(2000);
        builder.Property(c => c.cli_ativo).IsRequired();
        builder.Property(c => c.cli_datainclusao).IsRequired();

        builder.HasOne(d => d.cbo)
            .WithMany(p => p.clientes)
            .HasForeignKey(d => d.cbo_id);

        builder.HasOne(d => d.pessoa)
            .WithMany(p => p.clientes)
            .HasForeignKey(d => d.pes_id);

    }
}