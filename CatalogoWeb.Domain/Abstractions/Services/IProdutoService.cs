using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IProdutoService
    {
        Task<PagedModel<ProdutoGradeDTO>> ListaProdutoComGradeFiltro(FiltrosGerais filtros, PagedParams paginacao);
        Task<PagedModel<ProdutoDTO>> ListarTodas(FiltrosProdutoListarTodos filtros, PagedParams paginacao);
        Task<ProdutoDTO> RetornaDadosProduto(long ProdutoId);
    }
}
