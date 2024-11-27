using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.DTO.Command.Usuario;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IUsuarioService
    {
        Task<PagedModel<Usuario>> BuscarTodos(FiltrosUsuarios filtros, PagedParams paginacao);
        Task<UsuarioDTO> Incluir(UsuarioInsertCommand dados);
        Task<bool> AlterarSenha(UsuarioNovaSenhaCommand usuario);
        Task<UsuarioDTO> RetornaUsuarioEmail(string email);
        Task<UsuarioDTO> Editar(UsuarioUpdateCommand dados);
    }
}
