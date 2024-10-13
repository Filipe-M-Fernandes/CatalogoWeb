using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class LogradouroMap : IEntityTypeConfiguration<Logradouro>
{
    public void Configure(EntityTypeBuilder<Logradouro> builder)
    {
        builder.ToTable("logradouro");
        builder.HasKey(l => l.log_id);
        builder.Property(l => l.log_logradouro).IsRequired().HasMaxLength(200);
    }
}