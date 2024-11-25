using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Marca
    {
        public long mar_id { get; set; }
        public int emp_id { get; set; }
        public string mar_nome { get; set; }
        public bool mar_ativa { get; set; }
        
        [JsonIgnore]
        public virtual Empresa empresa { get; set; }
        [JsonIgnore]
        public virtual ICollection<Produto> produtos { get; set; }
    }
}
