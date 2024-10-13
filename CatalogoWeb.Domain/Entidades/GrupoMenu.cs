namespace CatalogoWeb.Domain.Entidades
{
    public class GrupoMenu
    {
        public int grm_id { get; set; }
        public string grm_descricao { get; set; }
        public string grm_icone { get; set; }
        public int? grm_pai { get; set; }
        public int grm_ordem { get; set; }

        //public virtual GrupoMenu itempai { get; set; }
        public virtual ICollection<ItemMenu> itemmenus { get; set; }
    }
}
