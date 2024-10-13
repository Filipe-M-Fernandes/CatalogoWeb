using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class SubGrupo
    {
        public long sgp_id { get; set; }
        public long gru_id { get; set; }
        public string sgp_nome { get; set; }
        public bool sgp_ativo { get; set; }
        public DateTime? data_sincro { get; set; }
        public virtual Grupo grupo { get; set; }
        [JsonIgnore]
        public virtual ICollection<Produto> produtos { get; set; }
    }
}
