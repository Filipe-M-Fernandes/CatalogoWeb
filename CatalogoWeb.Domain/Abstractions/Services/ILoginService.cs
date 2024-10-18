using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface ILoginService
    {
        Task<UsuarioDTO> AutenticarAsync(Login login);
        Task SalvarUltimoLogin(Usuario user);
    }
}
