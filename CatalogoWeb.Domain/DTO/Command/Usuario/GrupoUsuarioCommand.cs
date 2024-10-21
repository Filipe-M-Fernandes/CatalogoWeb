namespace CatalogoWeb.Domain.DTO.Command.Usuario
{
    public class GrupoUsuarioCommand
    {
        public string gru_nome { get; set; }
        public string gru_descricao { get; set; }
        public bool gru_ativo { get; set; }
        public int emp_id { get; set; }
    }
}
