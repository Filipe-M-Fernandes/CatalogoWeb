using System.Text.Json.Serialization;

namespace CatalogoWeb.Domain.Entidades
{
    public class Usuario
    {
        public long usu_id { get; set; }
        public string usu_email { get; set; }
        public string usu_senha { get; set; }
        public string usu_nome { get; set; }
        public DateTime usu_datainclusao { get; set; }
        public bool usu_ativo { get; set; }
        public byte[]? usu_avatar { get; set; }
        public DateTime usu_ultimologin { get; set; }
        public bool usu_admin { get; set; }
        /*[JsonIgnore]
        public virtual ICollection<UsuarioAcesso> usuarioacessos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Vendedor> vendedores { get; set; }*/
        [JsonIgnore]
        public virtual ICollection<UsuariosLocais> usuarioslocais { get; set; }
    }
}
