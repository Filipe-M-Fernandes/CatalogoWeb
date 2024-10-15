
namespace CatalogoWeb.Domain.Entidades.Filtros
{
    public record PagedParams
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Order { get; set; }

    }
}
