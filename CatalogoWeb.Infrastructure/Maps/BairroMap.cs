using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class BairroMap : IEntityTypeConfiguration<Bairro>
{
    public void Configure(EntityTypeBuilder<Bairro> builder)
    {
        builder.ToTable("bairro");
        builder.HasKey(p => p.bai_id);

        builder.Property(b => b.bai_nome).IsRequired().HasMaxLength(100);
        builder.Property(b => b.bai_ativo).IsRequired();

    }
}