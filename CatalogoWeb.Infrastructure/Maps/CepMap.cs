using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class CepMap : IEntityTypeConfiguration<Cep>
{
    public void Configure(EntityTypeBuilder<Cep> builder)
    {
        builder.ToTable("cep");
        builder.HasKey(p => p.cep_id);
        builder.Property(c => c.cep_cep).IsRequired().HasMaxLength(CEP.CepMaxLength);

        builder.HasOne(d => d.cidade)
            .WithMany(p => p.ceps)
            .HasForeignKey(d => d.cid_id);
    }
}