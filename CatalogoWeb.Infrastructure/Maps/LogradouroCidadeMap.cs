using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class LogradouroCidadeMap : IEntityTypeConfiguration<LogradouroCidade>
{
    public void Configure(EntityTypeBuilder<LogradouroCidade> builder)
    {
        builder.ToTable("logradourocidade");
            
        builder.HasKey(e => e.lcd_id);

        builder.HasOne(d => d.bairro)
            .WithMany(p => p.logradourocidades)
            .HasForeignKey(d => d.bai_id);

        builder.HasOne(d => d.cep)
            .WithMany(p => p.logradourocidades)
            .HasForeignKey(d => d.cep_id);

        builder.HasOne(d => d.cidade)
            .WithMany(p => p.logradourocidades)
            .HasForeignKey(d => d.cid_id);

        builder.HasOne(d => d.logradouro)
            .WithMany(p => p.logradourocidades)
            .HasForeignKey(d => d.log_id);
    }
}