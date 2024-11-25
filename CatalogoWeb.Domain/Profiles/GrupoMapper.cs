using AutoMapper;
using CatalogoWeb.Domain.DTO.Command.Grupo;
using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Profiles
{
    public class GrupoMapper : Profile
    {
        public GrupoMapper()
        {
            CreateMap<GrupoInsertCommand, Grupo>();
            CreateMap<GrupoCommand, Grupo>();
        }
    }
}
