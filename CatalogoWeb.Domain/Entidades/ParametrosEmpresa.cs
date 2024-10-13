using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class ParametrosEmpresa
    {
        public int par_id { get; set; }
        public int emp_id { get; set; }
        [JsonIgnore]
        public virtual Empresa empresa { get; set; }
     
    }
}
