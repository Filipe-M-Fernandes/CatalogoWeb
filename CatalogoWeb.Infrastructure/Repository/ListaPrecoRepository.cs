using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories
{
    public class ListaPrecoRepository : RepositoryBase<ListaPreco, long>, IListaPrecoRepository
    {
        public ListaPrecoRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
        public override async Task<bool> UpsertAsync(ListaPreco entity)
        {
            var dadosExistentes = await dbSet.Where(x => x.ltp_id == entity.ltp_id)
                .FirstOrDefaultAsync();

            if (dadosExistentes == default)
                return await AddAsync(entity);

            Mapper.Map(entity, dadosExistentes);

            return true;
        }
        public override async Task<bool> UpsertAsNoTrakingAsync(ListaPreco entity)
        {
            var dadosExistentes = await FindFirstAsync(c => c.ltp_id == entity.ltp_id, default, true);

            if (dadosExistentes == default)
                return await AddAsync(entity);

            Mapper.Map(entity, dadosExistentes);

            return true;
        }

        public override async Task<bool> DeleteAsync(long id)
        {
            var dadosExistentes = await dbSet.Where(x => x.ltp_id == id)
                .FirstOrDefaultAsync();

            if (dadosExistentes == default) return false;

            dbSet.Remove(dadosExistentes);

            return true;
        }
    }
}
