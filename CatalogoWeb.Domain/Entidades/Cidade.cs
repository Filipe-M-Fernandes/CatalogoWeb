using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Cidade
    {
        public int cid_id { get; set; }
        public int est_id { get; set; }
        public string cid_descricao { get; set; }
        public bool cid_capitalestado { get; set; }
        public bool cid_capitalpais { get; set; }
        public int? cid_ibge { get; set; }
        public string cid_codigotom { get; set; }
        public string cid_numcepinicial { get; set; }
        public string cid_numcepfinal { get; set; }
        public string cid_ddd1 { get; set; }
        public string cid_ddd2 { get; set; }
        public bool cid_status { get; set; }
        public virtual Estado estado { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cep> ceps { get; set; }
        [JsonIgnore]
        public virtual ICollection<LogradouroCidade> logradourocidades { get; set; }
    }
}
