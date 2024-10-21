using CatalogoWeb.Domain.DTO.Command.Usuario;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public interface IAvatarService
    {
        Task<byte[]> InserirAvatar(string usu_email, UsuarioAvatar avatar);
        Task<byte[]> VerificaAvatar(UsuarioUpdateCommand dados);
        Task<byte[]> ConverteAvatar(UsuarioAvatar avatar);
        Task<byte[]> CarregaAvatar(string email);
    }
}
