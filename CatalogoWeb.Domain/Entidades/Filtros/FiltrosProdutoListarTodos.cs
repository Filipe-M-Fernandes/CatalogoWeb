using CatalogoWeb.Domain.Enuns;

namespace CatalogoWeb.Domain.Entidades.Filtros
{
    public class FiltrosProdutoListarTodos
    {
        public string Filtro { get; set; }
        [System.ComponentModel.DefaultValue(null)]
        public long? IdProduto { get; set; }
        [System.ComponentModel.DefaultValue(null)]
        public long? IdMarca { get; set; }
        [System.ComponentModel.DefaultValue(null)]
        public long? IdGrupo { get; set; }
        [System.ComponentModel.DefaultValue(null)]
        public long? IdSubGrupo { get; set; }
        [System.ComponentModel.DefaultValue(null)]
        public decimal? PrecoMinimo { get; set; }
        [System.ComponentModel.DefaultValue(null)]
        public decimal? PrecoMaximo { get; set; }
        [System.ComponentModel.DefaultValue(null)]
        public AtivoInativo Ativo { get; set; } = (AtivoInativo)Enum.Parse(typeof(AtivoInativo), "Ativo");
        [System.ComponentModel.DefaultValue(null)]
        public string FiltroAdicional { get; set; }
    }
}
