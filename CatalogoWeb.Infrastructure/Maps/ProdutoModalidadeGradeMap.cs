using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps;

public class ProdutoModalidadeGradeMap : IEntityTypeConfiguration<ProdutoModalidadeGrade>
{
    public void Configure(EntityTypeBuilder<ProdutoModalidadeGrade> builder)
    {
        builder.ToTable("produto_modalidadegrade");
        builder.HasKey(ul => new { ul.prg_id, ul.mgp_id });

        builder.Property(p => p.prg_id)
              .HasColumnName("prg_id")
              .IsRequired();

        builder.Property(p => p.mgp_id)
            .HasColumnName("mgp_id")
            .IsRequired();

        builder.HasOne(ul => ul.modalidadegrade)
            .WithMany(u => u.produtomodalidadegrade)
            .HasForeignKey(ul => ul.mgp_id);

        builder.HasOne(ul => ul.produtograde)
            .WithMany(u => u.produtomodalidadegrade)
            .HasForeignKey(ul => ul.prg_id);
    }
}