using AutoMapper;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure.Repositories
{
    public class ListaPrecoClienteRepository : RepositoryBase<ListaPrecoCliente, long>, IListaPrecoClienteRepository
    {
        public ListaPrecoClienteRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
       
    }
}
