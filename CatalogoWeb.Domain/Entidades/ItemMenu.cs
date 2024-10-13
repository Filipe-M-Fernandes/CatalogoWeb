namespace CatalogoWeb.Domain.Entidades
{
    public class ItemMenu
    {
        public int itm_id { get; set; }
        public int grm_id { get; set; }
        public string itm_descricao { get; set; }
        public string itm_rota { get; set; }
        public string itm_icone { get; set; }
        public int itm_ordem { get; set; }
        public int itp_id { get; set; }
        public bool? itp_exibesomenteadm { get; set; }

        public virtual GrupoMenu grupomenu { get; set; }
    }
}
