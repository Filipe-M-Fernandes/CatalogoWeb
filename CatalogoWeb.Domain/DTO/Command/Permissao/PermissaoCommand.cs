namespace CatalogoWeb.Domain.DTO.Command.Permissao
{
    public abstract class PermissaoCommand
    {
        public long usu_id { get; set; }
        public int emp_id { get; set; }
        public string pru_nome { get; set; }
        public string pru_permissoes { get; set; }
        public long gru_id { get; set; }
        public string prg_nome { get; set; }
        public string prg_permissoes { get; set; }
    }
}
