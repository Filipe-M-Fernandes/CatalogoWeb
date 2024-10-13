using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class EstadoMap : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("estado");
        builder.HasKey(e => e.est_id);
        
        builder.Property(e => e.est_descricao).HasMaxLength(200);
        builder.Property(e => e.est_sigla).IsRequired().HasMaxLength(2);
        builder.Property(e => e.est_status).IsRequired();
        builder.Property(e => e.est_codigocno).HasMaxLength(20);
        builder.Property(e => e.est_siglanfeexterior).HasMaxLength(2);
        builder.Property(e => e.est_formatotelefone).HasMaxLength(20);
        builder.Property(e => e.est_valornfcesemconsumidor).HasPrecision(18,2);


        builder.HasOne(d => d.pais)
            .WithMany(p => p.estados)
            .HasForeignKey(d => d.pse_id);

    }
}