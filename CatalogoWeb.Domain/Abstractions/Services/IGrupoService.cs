using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.DTO.Command.Grupo;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IGrupoService
    {
        Task<PagedModel<Grupo>> Buscar(FiltrosGrupoProduto filtros, PagedParams paginacao);
        Task<Grupo> IncluirAsync(GrupoInsertCommand dados);
        Task<Grupo> AlterarAsync(GrupoUpdateCommand dados);
        Task<bool> ExcluirAsync(long id);
    }
}
