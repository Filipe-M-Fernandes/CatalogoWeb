using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class PessoaTelefoneMap : IEntityTypeConfiguration<PessoaTelefone>
{
    public void Configure(EntityTypeBuilder<PessoaTelefone> builder)
    {
        builder.ToTable("pessoatelefone");

        builder.HasKey(pt => pt.psc_id);
        builder.Property(pt => pt.psc_numero).IsRequired().HasMaxLength(20);
        builder.Property(pt => pt.psc_ramal).HasMaxLength(20);
        builder.Property(pt => pt.psc_principal).IsRequired();
        builder.Property(pt => pt.psc_ativo).IsRequired();

        builder.HasOne(d => d.pessoa)
             .WithMany(p => p.pessoatelefones)
             .HasForeignKey(d => d.pes_id);

        builder.HasOne(d => d.tipotelefone)
             .WithMany(p => p.pessoatelefones)
             .HasForeignKey(d => d.tpt_id);
    }
}