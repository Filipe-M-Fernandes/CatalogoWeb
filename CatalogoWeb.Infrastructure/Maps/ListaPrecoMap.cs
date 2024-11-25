using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ListaPrecoMap : IEntityTypeConfiguration<ListaPreco>
{
    public void Configure(EntityTypeBuilder<ListaPreco> builder)
    {
        builder.ToTable("listapreco");
        builder.HasKey(l => l.ltp_id);
        builder.Property(l => l.emp_id).IsRequired();
        builder.Property(l => l.ltp_nome).IsRequired().HasMaxLength(50);
        builder.Property(l => l.ltp_principal).IsRequired();
        builder.Property(l => l.ltp_ativa).IsRequired();

        builder.HasOne(d => d.empresa)
            .WithMany(p => p.listaprecos)
            .HasForeignKey(d => d.emp_id);

        builder.HasOne(d => d.local)
            .WithMany(p => p.listaprecos)
            .HasForeignKey(d => d.loc_id);
    }
}