using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class ListaPreco
    { 
        public long ltp_id { get; set; }
        public int emp_id { get; set; }
        public long? loc_id { get; set; }
        public string ltp_nome { get; set; }
        public DateTime? ltp_datainicial { get; set; }
        public DateTime? ltp_datafinal { get; set; }
        public bool ltp_principal { get; set; }
        public bool ltp_ativa { get; set; }
        [JsonIgnore]
        public virtual Empresa empresa { get; set; }
        [JsonIgnore]
        public virtual Local local { get; set; }
        [JsonIgnore]
        public virtual ICollection<ListaPrecoItem> listaprecoitens { get; set; }
    }
}
