using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuario");

        builder.HasKey(p => p.usu_id);

        builder.Property(p => p.usu_id).IsRequired();
        builder.Property(p => p.usu_email).HasMaxLength(254);
        builder.Property(p => p.usu_senha).HasMaxLength(150);
        builder.Property(p => p.usu_nome).HasMaxLength(255);
        builder.Property(p => p.usu_datainclusao).IsRequired();
        builder.Property(p => p.usu_ativo).IsRequired();
        builder.Property(p => p.usu_ultimologin).IsRequired();
        builder.Property(p => p.usu_admin).IsRequired();

    }
}