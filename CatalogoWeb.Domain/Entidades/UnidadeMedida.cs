using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class UnidadeMedida
    {

        public string ump_id { get; set; }
        public string ump_descricao { get; set; }
        public int ump_casasdecimais { get; set; }
        public DateTime? data_sincro { get; set; }
        [JsonIgnore]
        public virtual ICollection<Produto> produtos { get; set; }
        public virtual ICollection<ProdutoUnidade> produtounidades { get; set; }
    }
}
