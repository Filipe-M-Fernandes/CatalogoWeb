using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class PessoaJuridicaMap : IEntityTypeConfiguration<PessoaJuridica>
{
    public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
    {
        builder.ToTable("pessoajuridica");
        builder.HasKey(pj => pj.pej_id);
        builder.Property(pj => pj.pej_nomefantasia).HasMaxLength(150);
        builder.Property(pj => pj.pej_pessoacontato).HasMaxLength(150);

        builder.HasOne(d => d.pessoa)
            .WithMany(p => p.pessoajuridicas)
            .HasForeignKey(d => d.pes_id);
    }
}