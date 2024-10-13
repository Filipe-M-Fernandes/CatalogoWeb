using System.Text.Json.Serialization;
namespace CatalogoWeb.Domain.Entidades;

public class ListaPrecoCliente
{
    public long cli_id { get; set; }
    public long ltp_id { get; set; }
    [JsonIgnore]
    public virtual ListaPreco listaPreco { get; set; }
    [JsonIgnore]
    public virtual Cliente cliente { get; set; }
}
