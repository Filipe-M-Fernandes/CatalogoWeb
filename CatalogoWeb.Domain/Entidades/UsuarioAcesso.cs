using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class UsuarioAcesso
    {
        public long uac_id { get; set; }
        public long usu_id { get; set; }
        public int emp_id { get; set; }
        public int uac_dia { get; set; }
        public DateTime? uac_horainicial { get; set; }
        public DateTime? uac_horafinal { get; set; }
        public bool uac_bloqueado { get; set; }
        [JsonIgnore]
        public virtual Empresa empresa { get; set; }
        [JsonIgnore]
        public virtual Usuario usuario { get; set; }
    }
}
