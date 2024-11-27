using AutoMapper;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.DTO.Command.Usuario;
using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Profiles
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioInsertCommand, Usuario>();
            CreateMap<UsuarioCommand, Usuario>();
            CreateMap<UsuarioUpdateCommand, Usuario>();
            CreateMap<UsuarioInsertCommand, UsuarioUpdateCommand>();

        }
    }
}
