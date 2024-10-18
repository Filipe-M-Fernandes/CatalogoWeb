namespace CatalogoWeb.Domain.Entidades.Filtros
{
    public class FiltrosLocal
    {
        public long idUser { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }
        public bool? Ativo { get; set; }
        public bool? Matriz { get; set; }
        public string NomeFantasia { get; set; }
        public string Filtro { get; set; }
        public int? CodigoEmpresa { get; set; }
    }
}
