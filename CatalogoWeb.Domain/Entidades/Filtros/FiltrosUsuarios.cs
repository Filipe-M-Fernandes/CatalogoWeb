using CatalogoWeb.Domain.Enuns;

namespace CatalogoWeb.Domain.Entidades.Filtros
{
    public class FiltrosUsuarios
    {
        public string? Filtro { get; set; }
        public string? Email { get; set; }
        public string? Nome { get; set; }
        public long? IdUser { get; set; }
        public long? IdGrupo { get; set; }  
        public bool? Ativo { get; set; }
        public bool? Admin { get; set; }
    }
}
