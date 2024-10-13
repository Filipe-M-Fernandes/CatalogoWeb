using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class UsuarioAcessoMap : IEntityTypeConfiguration<UsuarioAcesso>
{
    public void Configure(EntityTypeBuilder<UsuarioAcesso> builder)
    {
        builder.ToTable("usuarioacesso");

        builder.HasKey(u => u.uac_id);
        builder.Property(u => u.usu_id).IsRequired();
        builder.Property(u => u.uac_dia).IsRequired();


        builder.HasOne(d => d.empresa)
            .WithMany(p => p.usuarioacessos)
            .HasForeignKey(d => d.emp_id);

        builder.HasOne(d => d.usuario)
            .WithMany(p => p.usuarioacessos)
            .HasForeignKey(d => d.usu_id);
    }
}