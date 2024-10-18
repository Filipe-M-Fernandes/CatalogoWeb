namespace CatalogoWeb.Domain.Entidades.Filtros
{
    public class FiltrosEmpresa
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public bool? Ativo { get; set; }
        public int? IdEmpresa { get; set; }
        public string Filtro { get; set; }
    }
}
