using AutoMapper;
using CatalogoWeb.Core;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure;

namespace CatalogoWeb.Services
{
    public class LoginService:ILoginService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public LoginService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> AutenticarAsync(Login login)
        {
            string senha = Base64Helper.DecodeFrom64(login.Senha);
            var users = await _unitOfWork.Usuarios.FindFirstAsync(u => u.usu_email == login.Email && u.usu_senha == CriptografiaHelper.Sha256(senha));

            if (users == null)
            {
                return null;
            }

            UsuarioDTO user = _mapper.Map<UsuarioDTO>(users);
            if ((login.CodigoEmpresa ?? 0) > 0 && (login.CodigoLocal ?? 0) > 0)
            {
                var local = await _unitOfWork.Locais.WhereLocalIncludeEmpresa(login.CodigoEmpresa.Value, login.CodigoLocal.Value);
                if (local != null)
                {
                    _mapper.Map(local, user);
                }
            }
            await SalvarUltimoLogin(users);
            return user;
        }

        public async Task SalvarUltimoLogin(Usuario user)
        {
            var usuario = await _unitOfWork.Usuarios.FindFirstAsync(u => u.usu_id == user.usu_id, default, true);
            usuario.usu_ultimologin = DateTime.Now;
            await _unitOfWork.Usuarios.UpsertAsNoTrakingAsync(usuario);
            await _unitOfWork.CommitAsync();
        }
    }
}
