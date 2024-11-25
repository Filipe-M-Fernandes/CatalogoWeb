namespace CatalogoWeb.Domain.DTO
{
    public class BuscarAcessosDTO
    {
        public int EmpId { get; set; }
        public List<ProdutoAcessoDTO> ListaProdutos { get; set; }
        public List<GrupoAcessoDTO> ListaGrupos { get; set; }
    }

    public class ProdutoAcessoDTO
    {
        public int ProId { get; set; }
        public int? PrgId { get; set; }
        public decimal Acessos { get; set; }
        public string Descricao { get; set; }
    }

    public class GrupoAcessoDTO
    {
        public int GruId { get; set; }
        public decimal Acessos { get; set; }
        public string Descricao { get; set; }
    }
}
