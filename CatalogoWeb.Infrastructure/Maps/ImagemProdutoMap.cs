using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps
{
    public class ImagemProdutoMap : IEntityTypeConfiguration<ImagemProduto>
    {
        public void Configure(EntityTypeBuilder<ImagemProduto> builder)
        {
            builder.ToTable("imagemproduto");
            builder.HasKey("imp_id");
        }
    }
}
