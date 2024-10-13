using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class ListaPrecoVendedor
    {
        public long ltp_id { get; set; }
        public long ven_id { get; set; }
        [JsonIgnore]
        public virtual ListaPreco listaPreco { get; set; }
        [JsonIgnore]
        public virtual Vendedor vendedor { get; set; }
    }
}
