using AutoMapper;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories;
public class ProdutoUnidadesRepository : RepositoryBase<ProdutoUnidade, long>, IProdutoUnidadesRepository
{
    public ProdutoUnidadesRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }

   

}