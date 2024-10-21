namespace CatalogoWeb.Domain.Entidades.Filtros
{
    public class FiltrosSubGrupo
    {
        public long? Codigo { get; set; }
        public string Nome { get; set; }
        public string Filtro { get; set; }
        public bool? Ativo { get; set; }
        public long? CodigoGrupo { get; set; }
    }
}
