using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ParametrosEmpresaMap : IEntityTypeConfiguration<ParametrosEmpresa>
{
    public void Configure(EntityTypeBuilder<ParametrosEmpresa> builder)
    {
        builder.ToTable("parametrosempresa");

        builder.HasKey(pa => pa.par_id);
        builder.Property(pa => pa.emp_id).IsRequired();

        builder.HasOne(d => d.empresa)
            .WithMany(p => p.parametrosempresas)
            .HasForeignKey(d => d.emp_id);
    }
}