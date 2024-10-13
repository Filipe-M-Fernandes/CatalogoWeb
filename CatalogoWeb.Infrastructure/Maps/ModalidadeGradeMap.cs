using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ModalidadeGradeMap : IEntityTypeConfiguration<ModalidadeGrade>
{
    public void Configure(EntityTypeBuilder<ModalidadeGrade> builder)
    {

        builder.ToTable("modalidadegrade");

        builder.HasKey(mg => mg.mgp_id);
        builder.Property(mg => mg.mgp_descricao).HasMaxLength(50).IsRequired();
        builder.Property(mg => mg.mgp_imprimenaetiqueta);


        builder.HasOne(d => d.empresa)
            .WithMany(p => p.modalidadesgrades)
            .HasForeignKey(d => d.emp_id);

        builder.HasMany(d => d.ModalidadeGradePai)
            .WithOne()
            .HasForeignKey(d => d.mgp_modalidade)
            .HasPrincipalKey(d => d.mgp_id);

    }
}