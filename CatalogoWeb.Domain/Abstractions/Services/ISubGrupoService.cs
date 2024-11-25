using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.DTO.Command.SubGrupo;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.Entidades.Filtros;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface ISubGrupoService
    {
        Task<SubGrupo> BuscarAsync(long Id);
        Task<PagedModel<SubGrupo>> Listar(FiltrosSubGrupo filtros, PagedParams paginacao);
        Task<SubGrupo> Incluir(SubGrupoInsertCommand dados);
        Task<SubGrupo> Alterar(SubGrupoUpdateCommand dados);
        Task<bool> Excluir(long Id);
    }
}
