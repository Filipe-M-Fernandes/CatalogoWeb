using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class StatusPedido
    {
        public long stp_id { get; set; }
        public int emp_id { get; set; }
        public string stp_descricao { get; set; }
        public bool stp_ativo { get; set; }
        public DateTime? data_sincro { get; set; }
        [JsonIgnore]
        public virtual Empresa empresa { get; set; }
    }
}
