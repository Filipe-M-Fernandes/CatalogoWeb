using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IUsuarioService
    {
        Task<PagedModel<Usuario>> BuscarTodos(FiltrosUsuarios filtros, PagedParams paginacao);
    }
}
