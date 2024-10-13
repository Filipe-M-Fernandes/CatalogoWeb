using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class PessoaFisicaMap : IEntityTypeConfiguration<PessoaFisica>
{
    public void Configure(EntityTypeBuilder<PessoaFisica> builder)
    {
        builder.ToTable("pessoafisica");

        builder.HasKey(pf => pf.pef_id);
        builder.Property(pf => pf.pef_rg).HasMaxLength(15);
        builder.Property(pf => pf.pef_rgorgaoexpedidor).HasMaxLength(20);
        builder.Property(pf => pf.pef_rguf).HasMaxLength(2);
        builder.Property(pf => pf.pef_apelido).HasMaxLength(50);
        builder.Property(pf => pf.pef_sexo).HasMaxLength(1);
      
        builder.HasOne(d => d.pessoa)
            .WithMany(p => p.pessoafisicas)
            .HasForeignKey(d => d.pes_id);
    }
}