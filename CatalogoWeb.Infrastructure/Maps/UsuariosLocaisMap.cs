using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps
{
    public class UsuariosLocaisMap : IEntityTypeConfiguration<UsuariosLocais>
    {
        public void Configure(EntityTypeBuilder<UsuariosLocais> builder)
        {
            builder.ToTable("usuario_local");
            builder.HasKey(l => new { l.loc_id, l.usu_id });

            builder.Property(p => p.loc_id)
           .HasColumnName("loc_id")
           .IsRequired();

            builder.Property(p => p.usu_id)
                .HasColumnName("usu_id")
                .IsRequired();
            
            builder.HasOne(l => l.locais)
                .WithMany(x => x.usuarioslocais)
                .HasForeignKey(c => c.loc_id);

            builder.HasOne(u => u.usuarios)
                .WithMany(y => y.usuarioslocais)
                .HasForeignKey(d => d.usu_id);
        }
    }
}
