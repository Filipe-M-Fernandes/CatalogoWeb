namespace CatalogoWeb.Domain.DTO
{
    public class UsuarioDTO
    {
        public int usu_id { get; set; }
        public string usu_nome { get; set; }
        public string usu_email { get; set; }
        public bool usu_admin { get; set; }
        public bool usu_ativo { get; set; }
        public int? emp_id { get; set; }
        public string emp_nomefantasia { get; set; }
        public long? loc_id { get; set; }
        public string loc_descricao { get; set; }
        public byte[] usu_avatar { get; set; }
    }
}
