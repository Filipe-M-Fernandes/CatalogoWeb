using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IListaPrecoItemService
    {
        Task<List<ListaPrecoItem>> Listar(long proId);
    }
}
