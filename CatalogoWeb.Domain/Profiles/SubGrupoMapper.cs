using AutoMapper;
using CatalogoWeb.Domain.DTO.Command.SubGrupo;
using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Profiles
{
    public class SubGrupoMapper : Profile
    {
        public SubGrupoMapper()
        {
            CreateMap<SubGrupoInsertCommand, SubGrupo>();
        }

    }
}
