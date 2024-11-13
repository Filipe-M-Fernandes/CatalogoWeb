using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class EmpresaMap : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("empresa");

        builder.HasKey(p => p.emp_id);

        builder.Property(p => p.emp_ativa).IsRequired();
        builder.Property(e => e.emp_nomefantasia).IsRequired().HasMaxLength(120);
        builder.Property(e => e.emp_razaosocial).IsRequired().HasMaxLength(200);
        builder.Property(e => e.emp_ativa).IsRequired();
        builder.Property(e => e.emp_datainclusao).IsRequired();

       

    }
}