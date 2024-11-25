using CatalogoWeb.Domain.Enuns;

namespace CatalogoWeb.Domain.Entidades.Filtros
{
    public class FiltrosProdutoListarTodos
    {
        public string? Filtro { get; set; }
        public long? IdProduto { get; set; }
        public long? IdMarca { get; set; }
        public long? IdGrupo { get; set; }
        public long? IdSubGrupo { get; set; }
        public AtivoInativo? Ativo { get; set; } = (AtivoInativo)Enum.Parse(typeof(AtivoInativo), "Ativo");
        public string? FiltroAdicional { get; set; }
    }
}
