using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.Entidades.Filtros;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IMarcaService
    {
        Task<Marca> Incluir(Marca entidade);
        Task<Marca> Alterar(Marca entidade);
        Task<bool> Excluir(long Id);
        Task<Marca> BuscarAsync(long Id);
        Task<PagedModel<Marca>> Listar(FiltrosMarca filtros, PagedParams paginacao);
    }
}
