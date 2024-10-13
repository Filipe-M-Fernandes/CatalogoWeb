using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class PessoaEnderecoMap : IEntityTypeConfiguration<PessoaEndereco>
{
    public void Configure(EntityTypeBuilder<PessoaEndereco> builder)
    {
        builder.ToTable("pessoaendereco");

        builder.HasKey(pe => pe.pee_id);
        builder.Property(pe => pe.pee_complemento).HasMaxLength(200);
        builder.Property(pe => pe.pee_localreferencia).HasMaxLength(200);
        builder.Property(pe => pe.pee_ativo).IsRequired();
        builder.Property(pe => pe.pee_enderecoprincipal).IsRequired();
        builder.Property(pe => pe.pee_numero).HasMaxLength(15);
        

        builder.HasOne(d => d.logradourocidade)
             .WithMany(p => p.pessoaenderecos)
             .HasForeignKey(d => d.lcd_id);

        builder.HasOne(d => d.pessoa)
            .WithMany(p => p.pessoaenderecos)
            .HasForeignKey(d => d.pes_id);

        builder.HasOne(d => d.tipoendereco)
            .WithMany(p => p.pessoaenderecos)
            .HasForeignKey(d => d.tpe_id);
    }
}