using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Vendedor
    {
        public long ven_id { get; set; }
        public long pes_id { get; set; }
        public long loc_id { get; set; }
        public long? usu_id { get; set; }
        public decimal? ven_maximodesconto { get; set; }
        public bool ven_ativo { get; set; }
        
        [JsonIgnore]
        public virtual Local local { get; set; }
        [JsonIgnore]
        public virtual Usuario usuario { get; set; }
       /*[JsonIgnore]
        public virtual ICollection<Comissao> comissoes { get; set; }
        [JsonIgnore]
        public virtual ICollection<MetaVenda> metavenda { get; set; }*/
    }
}
