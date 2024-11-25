using AutoMapper;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure.Repositories;
using CatalogWeb.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogoWeb.Infrastructure.Repository
{
    public class ImagemProdutoRepository : RepositoryBase<ImagemProduto, long>, IImagemProdutoRepository
    {
        public ImagemProdutoRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
        public override async Task<bool> UpsertAsync(ImagemProduto entity)
        {
            var dadosExistentes = await dbSet.Where(x => x.imp_id == entity.imp_id)
                .FirstOrDefaultAsync();

            if (dadosExistentes == default)
                return await AddAsync(entity);

            Mapper.Map(entity, dadosExistentes);

            return true;
        }
        public override async Task<bool> UpsertAsNoTrakingAsync(ImagemProduto entity)
        {
            var dadosExistentes = await FindFirstAsync(c => c.imp_id == entity.imp_id, default, true);

            if (dadosExistentes == default)
                return await AddAsync(entity);

            Mapper.Map(entity, dadosExistentes);

            return true;
        }

        public override async Task<bool> DeleteAsync(long id)
        {
            var dadosExistentes = await dbSet.Where(x => x.imp_id == id)
                .FirstOrDefaultAsync();

            if (dadosExistentes == default) return false;

            dbSet.Remove(dadosExistentes);

            return true;
        }
    }
}
