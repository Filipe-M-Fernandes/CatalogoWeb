using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace CatalogoWeb.Infrastructure.Maps;

public class LocalMap : IEntityTypeConfiguration<Local>
{
    public void Configure(EntityTypeBuilder<Local> builder)
    {
        builder.ToTable("local");

        builder.HasKey(l => l.loc_id);

        builder.Property(l => l.loc_codigo).IsRequired().HasMaxLength(20);
        builder.Property(l => l.loc_descricao).IsRequired().HasMaxLength(100);
        builder.OwnsOne(l => l.loc_cnpj).Property(b => b.Numero).HasColumnName("loc_cnpj").IsRequired().HasMaxLength(CNPJ.CnpjMaxLength);
        builder.OwnsOne(l => l.loc_inscricaoestadual).Property(b => b.NumeroInscricaoEstadual).HasColumnName("loc_inscricaoestadual");
        builder.OwnsOne(l => l.loc_inscricaoestadual).Property(b => b.UfEstado).HasColumnName("loc_inscricaoestadual_ufestado").HasMaxLength(2);
        builder.Property(l => l.loc_inscricaomunicipal).HasMaxLength(20);
        builder.OwnsOne(l => l.loc_email).Property(b => b.Endereco).HasColumnName("loc_email").IsRequired().HasMaxLength(Email.EnderecoMaxLength);
        builder.OwnsOne(l => l.loc_cpfresponsavel).Property(b => b.Numero).HasColumnName("loc_cpfresponsavel").IsRequired().HasMaxLength(CPF.CpfMaxLength);
        builder.Property(l => l.loc_numeroestabelecimento).IsRequired();
        builder.Property(l => l.loc_substitutotributario).IsRequired();
        builder.Property(l => l.loc_ativo).IsRequired();
        builder.Property(l => l.loc_datainclusao).IsRequired();
        builder.Property(l => l.loc_matriz).IsRequired();
        builder.Property(l => l.loc_tipocontribuinte).IsRequired();
        builder.Property(l => l.loc_nomefantasia).HasMaxLength(120);
        builder.Property(l => l.loc_codigoantt).HasMaxLength(8);

         builder.HasOne(d => d.empresa)
            .WithMany(p => p.locais)
            .HasForeignKey(d => d.emp_id);

        builder.HasOne(d => d.logradouroCidade)
            .WithMany(p => p.locais)
            .HasForeignKey(d => d.lcd_id);

        builder.HasOne(p => p.parametrolocal)
            .WithOne(d => d.local)
            .HasForeignKey<ParametrosLocal>(d => d.loc_id);

     
    }
}