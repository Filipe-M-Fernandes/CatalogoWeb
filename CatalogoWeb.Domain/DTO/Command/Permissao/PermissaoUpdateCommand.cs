namespace CatalogoWeb.Domain.DTO.Command.Permissao
{
    public class PermissaoUpdateCommand: PermissaoCommand
    {
        public Guid Id { get; set; }
        public string pagina { get; set; }
        public bool acesso { get; set; }
    }
}
