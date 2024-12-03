using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IListaPrecoService
    {
        Task<List<ListaPreco>> Listar();
    }
}
