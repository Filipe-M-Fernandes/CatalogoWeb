using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class ProdutoGrade
    {

        public long prg_id { get; set; }
        public long pro_id { get; set; }
        public string prg_ean { get; set; }
        public bool prg_ativa { get; set; }
        public string prg_descricao { get; set; }
        [JsonIgnore]
        public virtual Produto produto { get; set; }
        [JsonIgnore]
        public virtual ICollection<ListaPrecoItem> listaprecoitens { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProdutoEstoque> produtoestoques { get; set; }
    }
}
