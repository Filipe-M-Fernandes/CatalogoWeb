using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class UsuariosLocais
    {
        public long usu_id { get; set; }
        public long loc_id { get; set; }
        [JsonIgnore]
        public virtual Usuario usuarios { get; set; }
        [JsonIgnore]
        public virtual Local locais { get; set; }
    }
}
