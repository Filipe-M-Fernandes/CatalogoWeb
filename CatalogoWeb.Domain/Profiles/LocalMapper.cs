using AutoMapper;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Profiles
{
    public class LocalMapper : Profile
    {
        public LocalMapper()
        {
            CreateMap<Local, UsuarioDTO>();
        }
    }
}
