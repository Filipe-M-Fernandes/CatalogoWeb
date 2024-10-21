namespace CatalogoWeb.Domain.DTO.Command.SubGrupo
{
    public class SubGrupoInsertCommand
    {
        public long gru_id { get; set; }
        public string sgp_nome { get; set; }
        public bool sgp_ativo { get; set; }
    }
}
