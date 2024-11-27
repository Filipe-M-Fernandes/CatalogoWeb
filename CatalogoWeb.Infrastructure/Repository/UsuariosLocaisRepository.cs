using AutoMapper;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories
{
    public class UsuariosLocaisRepository : RepositoryBase<UsuariosLocais, long>, IUsuariosLocaisRepository
    {
        public UsuariosLocaisRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) {}

    }
}
