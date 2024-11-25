using CatalogoWeb.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoWeb.Infrastructure.Maps
{
    public class ProdutosAcessoMap : IEntityTypeConfiguration<ProdutosAcesso>
    {
        public void Configure(EntityTypeBuilder<ProdutosAcesso> builder)
        {
            builder.ToTable("produtosacesso");
            builder.HasKey(p => p.pac_id);
        }           
    }               
}
