using AutoMapper;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure.Repositories;
using CatalogWeb.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogoWeb.Infrastructure.Repository
{
    public class ProdutoAcessoRepository : RepositoryBase<ProdutosAcesso, long>, IProdutosAcessoRepository
    {
        public ProdutoAcessoRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
        public override async Task<bool> UpsertAsync(ProdutosAcesso entity)
        {
            var dadosExistentes = await FindFirstAsync(x => x.pac_id == entity.pac_id);

            if (dadosExistentes == default)
                return await AddAsync(entity);

            Mapper.Map(entity, dadosExistentes);

            return true;
        }
        public override async Task<bool> UpsertAsNoTrakingAsync(ProdutosAcesso entity)
        {
            var dadosExistentes = await FindFirstAsync(p => p.pac_id == entity.pac_id, default, true);

            if (dadosExistentes == default)
                return await AddAsync(entity);

            Mapper.Map(entity, dadosExistentes);

            return true;
        }

        public override async Task<bool> DeleteAsync(long id)
        {
            var dadosExistentes = await dbSet.Where(x => x.pac_id == id)
                .FirstOrDefaultAsync();

            if (dadosExistentes == default) return false;

            dbSet.Remove(dadosExistentes);

            return true;
        }
    }
}
