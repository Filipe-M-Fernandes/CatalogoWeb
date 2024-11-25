namespace CatalogoWeb.Domain.Entidades.Filtros
{
    public class FiltrosGrupoProduto
    {
        public long? CodigoGrupo { get; set; }
        public string? NomeGrupo { get; set; }
        public string? Filtro { get; set; }
        public bool? ApenasAtivos { get; set; }
    }

}
