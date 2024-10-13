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
        builder.Property(e => e.emp_regimetributario);
        builder.Property(e => e.emp_enquadramentofiscal);
        builder.Property(e => e.emp_usasac).IsRequired();

        builder.HasOne(d => d.usuario)
            .WithMany(p => p.empresas)
            .HasForeignKey(d => d.usu_id);

        builder.HasOne(d => d.contador)
            .WithMany(p => p.empresas)
            .HasForeignKey(d => d.con_id);
    }
}