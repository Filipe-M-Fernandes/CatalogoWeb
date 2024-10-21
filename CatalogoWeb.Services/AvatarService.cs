using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.DTO.Command.Usuario;
using CatalogoWeb.Infrastructure;

namespace CatalogoWeb.Domain.Abstractions.Services
{
    public class AvatarService : IAvatarService
    {
        private IUnitOfWork _unitOfWork;
        private IDadosUsuarioLogado _dadosUsuarioLogado;

        public AvatarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<byte[]> InserirAvatar(string usu_email, UsuarioAvatar avatar)
        {
            byte[] usu_avatar = await CarregaAvatar(usu_email);

            if (avatar != null)
            {
                if (avatar.data != null && avatar.type != null)
                    usu_avatar = await ConverteAvatar(avatar);
            }

            return usu_avatar;
        }
        public async Task<byte[]> VerificaAvatar(UsuarioUpdateCommand dados)
        {
            byte[] usu_avatar;
            if (dados.avatar != null)
            {
                if (dados.avatar.data != null && dados.avatar.type != null)
                    usu_avatar = await ConverteAvatar(dados.avatar);
                else
                    usu_avatar = _unitOfWork.Usuarios.FindFirstAsync(u => u.usu_id == dados.usu_id).Result.usu_avatar;
            }
            else usu_avatar = _unitOfWork.Usuarios.FindFirstAsync(u => u.usu_id == dados.usu_id).Result.usu_avatar;

            return usu_avatar;
        }

        public async Task<byte[]> ConverteAvatar(UsuarioAvatar avatar)
        {
            var imagemBase64 = avatar.data;
            var tipoImagem = avatar.type;
            return Convert.FromBase64String(imagemBase64.Replace("data:" + tipoImagem + ";base64,", ""));

        }

        public async Task<byte[]> CarregaAvatar(string email)
        {
            byte[] avatarPadrao = File.ReadAllBytes($@"{Environment.CurrentDirectory}/Imagens/user.png");

            var user = await _unitOfWork.Usuarios.FindFirstAsync(u => u.usu_email.Equals(email));
            if (user == null || user.usu_avatar == null || user.usu_avatar.Length == 0) return avatarPadrao;

            return user.usu_avatar;
        }
    }
}
