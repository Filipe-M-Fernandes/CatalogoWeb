using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ParametrosLocalMap : IEntityTypeConfiguration<ParametrosLocal>
{
    public void Configure(EntityTypeBuilder<ParametrosLocal> builder)
    {
        builder.ToTable("parametroslocal");

        builder.HasKey(pa => pa.par_id);
        builder.Property(pa => pa.loc_id).IsRequired();
    }
}