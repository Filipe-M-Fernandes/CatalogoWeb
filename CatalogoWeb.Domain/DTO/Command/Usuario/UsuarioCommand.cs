using CatalogoWeb.Domain.DTO.Command.Permissao;
using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.DTO.Command.Usuario
{
    public abstract class UsuarioCommand
    {
        public string usu_email { get; set; }
        public string usu_nome { get; set; }
        public DateTime usu_datainclusao { get; set; }
        public DateTime usu_ultimologin { get; set; }
        public bool usu_ativo { get; set; }
        public bool usu_admin { get; set; }
        public bool usu_usuariopdv { get; set; }
        public string usu_senha { get; set; }
        public UsuarioAvatar avatar { get; set; }
        public ICollection<UsuarioLocalCommand> usuarioslocais { get; set; }
        public List<GrupoUsuarioCommand> grupousuarios { get; set; }
        public List<PermissaoUpdateCommand> listaPermissoesPaginas { get; set; }
    }
}
