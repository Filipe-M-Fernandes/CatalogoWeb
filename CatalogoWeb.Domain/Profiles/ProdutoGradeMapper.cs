using AutoMapper;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Profiles
{
    public class ProdutoGradeMapper : Profile
    {
        public ProdutoGradeMapper()
        {
            CreateMap<ProdutoGrade, ProdutoGradeDTO>();
        }
    }
}
