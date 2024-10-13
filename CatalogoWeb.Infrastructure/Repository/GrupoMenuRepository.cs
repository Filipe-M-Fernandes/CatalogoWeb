using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class GrupoMenuRepository : RepositoryBase<GrupoMenu, int>, IGrupoMenuRepository
{
    public GrupoMenuRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }


}