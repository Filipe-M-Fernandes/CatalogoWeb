using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class PessoaEmailMap : IEntityTypeConfiguration<PessoaEmail>
{
    public void Configure(EntityTypeBuilder<PessoaEmail> builder)
    {
        builder.ToTable("pessoaemail");

        builder.HasKey(pe => pe.pem_id);
        builder.Property(pe => pe.pem_emailprincipal).IsRequired();
        builder.Property(pe => pe.pem_ativo).IsRequired();

        builder.HasOne(d => d.pessoa)
            .WithMany(p => p.pessoaemails)
            .HasForeignKey(d => d.pes_id);
    }
}