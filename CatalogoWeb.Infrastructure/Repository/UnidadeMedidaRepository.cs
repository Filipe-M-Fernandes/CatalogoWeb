using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class UnidadeMedidaRepository : RepositoryBase<UnidadeMedida, long>, IUnidadeMedidaRepository    
{
    public UnidadeMedidaRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

}
