using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using AutoMapper;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;

public class ItemMenuRepository : RepositoryBase<ItemMenu, int>, IItemMenuRepository
{
    public ItemMenuRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }


}