using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class PessoaMap : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("pessoa");

        builder.HasKey(p => p.pes_id);
        builder.Property(p => p.pes_nome).IsRequired().HasMaxLength(200);
        builder.Property(p => p.pes_fisicajuridica).IsRequired();
        builder.Property(p => p.pes_datainclusao).IsRequired();
        builder.Property(p => p.pes_ativo).IsRequired();
        builder.Property(p => p.pes_idestrangeiro).HasMaxLength(50);
        builder.Property(p => p.pes_orgaopublico).IsRequired();
        builder.Property(p => p.pes_contato).IsRequired();
        builder.Property(p => p.pes_parceiro).IsRequired();

        builder.HasOne(d => d.empresa)
               .WithMany(p => p.pessoas)
               .HasForeignKey(d => d.emp_id);
    }
}