using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Grupo
    {
        public long gru_id { get; set; }
        public int emp_id { get; set; }
        public string gru_nome { get; set; }
        public bool gru_ativo { get; set; }
        public DateTime? data_sincro { get; set; }
        [JsonIgnore]
        public virtual Empresa empresa { get; set; }
        [JsonIgnore]
        public virtual ICollection<Produto> produtos { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubGrupo> subgrupos { get; set; }
    }
}
