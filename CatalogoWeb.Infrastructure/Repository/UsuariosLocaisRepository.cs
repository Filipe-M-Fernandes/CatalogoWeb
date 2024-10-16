using AutoMapper;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogWeb.Infrastructure.Context;
using Microsoft.Extensions.Logging;

namespace CatalogoWeb.Infrastructure.Repositories
{
    public class UsuariosLocaisRepository : RepositoryBase<UsuariosLocais, long>, IUsuariosLocaisRepository
    {
        public UsuariosLocaisRepository(CatalogoDbContext context, ILogger<UsuariosLocais> logger, IMapper mapper) : base(context, mapper) {}

    }
}
