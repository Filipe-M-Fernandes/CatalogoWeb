using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class ParametrosLocal
    {
        public long par_id { get; set; }
        public long loc_id { get; set; }
        public long? ope_id { get; set; }
        public DateTime? data_sincro { get; set; }
        public decimal? par_markupproduto { get; set; }      
        [JsonIgnore]
        public virtual Local local { get; set; }
    }
}
