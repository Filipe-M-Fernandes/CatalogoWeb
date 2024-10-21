namespace CatalogoWeb.Domain.DTO.Command.Usuario
{
    public class UsuarioUpdateCommand: UsuarioCommand
    {
        public long usu_id { get; set; }
        public bool mudarAcesso { get; set; }
    }
}
