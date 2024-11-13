using AutoMapper;
using CatalogoWeb.Domain.DTO.Command.Grupo;

namespace CatalogoWeb.Domain.Profiles
{
    public class GrupoMapper : Profile
    {
        public GrupoMapper()
        {
            CreateMap<GrupoInsertCommand, GrupoCommand>();
        }
    }
}
