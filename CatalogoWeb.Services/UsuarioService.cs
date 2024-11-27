using AutoMapper;
using CatalogoWeb.Core;
using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Core.Extensions;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.DTO.Command.Usuario;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Enuns;
using CatalogoWeb.Infrastructure;
using System;
using System.Linq.Expressions;
using System.Text;
using XSystem.Security.Cryptography;

namespace CatalogoWeb.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUnitOfWork _unitOfWork;
        private IDadosUsuarioLogado _dadosUsuarioLogado;
        private IMapper _mapper;
        private IAvatarService _avatarService;
        private IEnviaEmailService _enviaEmailService;
        public UsuarioService(IUnitOfWork unitOfWork, IDadosUsuarioLogado dadosUsuarioLogado, IMapper mapper, IAvatarService avatarService, IEnviaEmailService enviaEmailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _avatarService = avatarService;
            _dadosUsuarioLogado = dadosUsuarioLogado;
            _enviaEmailService = enviaEmailService;
        }

        public async Task<UsuarioDTO> IncluirAsync(Usuario entidade)
        {
            if (!await _unitOfWork.Usuarios.UpsertAsync(entidade)) return default;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UsuarioDTO>(entidade);
        }

        public async Task<PagedModel<Usuario>> BuscarTodos(FiltrosUsuarios filtros, PagedParams paginacao)
        {
            var filtro = MontarFiltroUsuarios(filtros);
            return await _unitOfWork.Usuarios.FindAsync(filtro, paginacao);
        }

        public async Task<Usuario> BuscarAsync(long id)
        {
            return await _unitOfWork.Usuarios.GetByIdAsync(id);
        }

        public async Task<UsuarioDTO> AlterarAsync(Usuario entidade)
        {
            if (!await _unitOfWork.Usuarios.UpsertAsync(entidade)) return default;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UsuarioDTO>(entidade);
        }

        public async Task<UsuarioDTO> Incluir(UsuarioInsertCommand dados)
        {
            Usuario entidade = _mapper.Map<Usuario>(dados);
            if (dados.avatar != null)
                entidade.usu_avatar = await _avatarService.InserirAvatar(dados.usu_email, dados.avatar);
            entidade.usu_datainclusao = DateTime.Today;
            entidade.usu_ultimologin = DateTime.Today;

            if (dados.usu_senha != null) entidade.usu_senha = await ConfirmarTrocaSenha(dados.usu_senha);

            UsuarioDTO retorno = await IncluirAsync(entidade);
            await VincularLocal(retorno.usu_id);

            await EnviarEmailAtivacaoUsuario(retorno.usu_email, retorno.usu_nome);

            return retorno;
        }

        public async Task<UsuarioDTO> Editar(UsuarioUpdateCommand dados)
        {
            if (await EmailCadastrado(dados.usu_email, dados.usu_id)) return default;

            var entidade = _mapper.Map<Usuario>(dados);
            var user = await _unitOfWork.Usuarios.FindFirstAsync(u => u.usu_id == dados.usu_id, new string[] { "usuarioslocais" });
            entidade.usuarioslocais = user.usuarioslocais;
            entidade.usu_ultimologin = user.usu_ultimologin;
            entidade.usu_senha = user.usu_senha;
            entidade.usu_datainclusao = user.usu_datainclusao;

            if (dados.usu_senha != null) entidade.usu_senha = await ConfirmarTrocaSenha(dados.usu_senha);

            /*entidade.usu_avatar = await VerificaAvatar(dados);
            if (dados.mudarAcesso) await ExcluirUsuarioAcesso(dados);*/

            await VincularLocal(user.usu_id);
            await AlterarAsync(entidade);

            UsuarioDTO retorno = _mapper.Map<UsuarioDTO>(entidade);
            return retorno;
        }

        private async Task<bool> EmailCadastrado(string email, long? idUsuario)
        {
            var emailNovo = await _unitOfWork.Usuarios.FindFirstAsync(e => e.usu_email == email);

            if (idUsuario != null && idUsuario != 0)
            {
                var alterarEmail = await _unitOfWork.Usuarios.FindFirstAsync(e => e.usu_email == email && e.usu_id == idUsuario);
                if (alterarEmail != null) return false;
            }

            return !(emailNovo == null);
        }

        public async Task<string> ConfirmarTrocaSenha(string nova)
        {
            var hashSenha = await GetHashPassword(nova);
            return hashSenha;
        }

        public async Task<string> GetHashPassword(string password)
        {
            SHA1Managed sha1 = new SHA1Managed();
            var senha = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "");
            return senha;
        }

        private async Task EnviarEmailAtivacaoUsuario(string email, string nome)
        {

            string linkAtivacaoContaUsuario = "http://localhost:3000/ativar-novo-usuario#/" + Convert.ToBase64String(Encoding.UTF8.GetBytes(email + "|" + nome));

            #region ImagemLogoPng
            string img = "https://drive.google.com/file/d/1VT4dOopp6g5evI9XvdcXBdn16RwY97lc/view?usp=sharing";
            #endregion

            #region Conteúdo do email em HTML
            string conteudoCorpoEmail = $@"<html xmlns=""http://www.w3.org/1999/xhtml"">
    <head>
        <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
        <title>Catálogo Web</title>
        <style>
            b {{
                font-weight: bold;
            }}

            table {{
                border-collapse: collapse;
            }}

            table, th, td {{
                color: #3c3c3c;
                font-size: 12px;
            }}

            th, td {{
                border: 0;
                vertical-align: middle;
            }}

            a {{
                display: inline-block;
                text-decoration: none;
            }}
        </style>
    </head>
    <body>
        <table width=""550"" border=""0"" align=""center"" cellspacing=""0"" cellpadding=""0"" style=""border: 1px solid #dddddd;"">
            
            <tr bgcolor=""#ffffff"">
                <td colspan=""3"" height=""10""></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td align=""center"">
                    <img src=""https://drive.google.com/uc?id=1VT4dOopp6g5evI9XvdcXBdn16RwY97lc"" height=""300"" alt=""Catálogo Web""  />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr bgcolor=""#ffffff"">
                <td colspan=""3"" height=""30""></td>
            </tr>
            <tr>
                <td colspan=""3"">
                    <table width=""100%"" border=""0"" align=""center"" cellspacing=""0"" cellpadding=""0"">
                        <tr bgcolor=""#0053a6"">
                            <td colspan=""3"" height=""10""></td>
                        </tr>
                        <tr bgcolor=""#ffffff"">
                            <td colspan=""3"" height=""8""></td>
                        </tr>
                        <tr bgcolor=""#ffffff"">
                            <td>&nbsp;</td>
                            <td align=""left"" style=""padding: 20px;"">
                                <div>
                                    <font face=""Helvetica, Arial, sans-serif"" color=""#0053a6"" style=""font-size: 21px;"">
                                        <b>&nbsp;&nbsp;&nbsp;&nbsp;Sr.(a) {nome}</b>
                                    </font>
                                </div>
                                <p>
                                    <font face=""Helvetica, Arial, sans-serif"" color=""#2b2b2b"" style=""font-size: 14px; text-align: justify; line-height: 18px;"">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Estamos muito felizes pelo seu interesse em nossa solução, esperamos que aproveite todos recursos disponíveis!
                                        <br /><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Está quase tudo pronto para juntos iniciarmos uma experiência incrível na gestão de sua empresa. Clicando no <b>botão abaixo</b> você poderá ativar sua conta e definir uma senha para seu usuário.
                                    </font>
                                </p>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr bgcolor=""#ffffff"">
                            <td colspan=""3"" height=""15""></td>
                        </tr>
                        <tr bgcolor=""#ffffff"">
                            <td colspan=""3"" height=""30"" align=""center"">
                                <a href=""{{linkAtivacaoContaUsuario}}"" target=""_blank"" style=""font-size: 22px; padding: 15px 30px; background-color: #14a3b3;"">
                                    <font face=""Helvetica, Arial, sans-serif"" color=""#ffffff"">
                                        DESEJO ATIVAR MINHA CONTA
                                    </font>
                                </a>
                            </td>
                        </tr>
                        <tr bgcolor=""#ffffff"">
                            <td colspan=""3"" height=""25""></td>
                        </tr>
                        <tr bgcolor=""#ffffff"">
                            <td colspan=""3"" align=""center"" height=""90"" style=""padding: 0 25px;"">
                                <font face=""Helvetica, Arial, sans-serif"" color=""#2b2b2b"" style=""font-size: 13px; line-height: 18px;"">
                                    Caso necessário acesse pelo link: 
                                    <a href=""{linkAtivacaoContaUsuario}"" target=""_blank"" style=""color: #2b2b2b;"">
                                        <u style=""word-wrap: break-word; word-break: break-all;"">{linkAtivacaoContaUsuario}</u>
                                    </a>
                                </font>
                            </td>
                        </tr>
                        <tr bgcolor=""#ffffff"">
                            <td colspan=""3"" height=""20""></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr bgcolor=""#ececec"">
                <td colspan=""3"" height=""10""></td>
            </tr>
            <tr bgcolor=""#ececec"">
                <td colspan=""3"" height=""20""></td>
            </tr>
        </table>
    </body>
</html>
";
            #endregion
            List<string> destinatarios = new List<string>();
            destinatarios.Add(email);

            await _enviaEmailService.EnviaEmail(email, "Bem vindo ao Catálogo Web!", conteudoCorpoEmail, true);

        }

        private async Task VincularLocal(long usuId)
        {
            long locId = _dadosUsuarioLogado.CodigoLocal();
            var ul = await _unitOfWork.UsuariosLocais.FindFirstAsync(u => u.usu_id == usuId && u.loc_id == locId);
            if (ul == null)
            {
                UsuariosLocais usuLoc = new UsuariosLocais()
                {
                    usu_id = usuId,
                    loc_id = locId
                };
                await _unitOfWork.UsuariosLocais.AddAsync(usuLoc);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<bool> AlterarSenha(UsuarioNovaSenhaCommand usuario)
        {
            var user = await _unitOfWork.Usuarios.FindFirstAsync(u => u.usu_email.Equals(usuario.usu_email));

            user.usu_ativo = true;
            user.usu_senha = CriptografiaHelper.Sha256(Base64Helper.DecodeFrom64(usuario.novaSenha));
            await _unitOfWork.Usuarios.UpsertAsNoTrakingAsync(user);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<UsuarioDTO> RetornaUsuarioEmail(string email)
        {
            Usuario usu = await _unitOfWork.Usuarios.FindFirstAsync(usu => usu.usu_email == email);
            return _mapper.Map<UsuarioDTO>(usu);
        }

        private Expression<Func<Usuario, bool>> MontarFiltroUsuarios(FiltrosUsuarios filtros)
        {
            var expr = PredicateBuilder.True<Usuario>();
            long codigoLocal = _dadosUsuarioLogado.CodigoLocal();
            expr = expr.And(x => x.usuarioslocais.Any(l => l.loc_id == codigoLocal));
            if (filtros.IdUser.HasValue)
            {
                if (filtros.IdUser.HasValue) expr = expr.And(x => x.usu_id == filtros.IdUser.Value);
            }
            else
            {
                if (filtros.Admin.HasValue) expr = expr.And(x => x.usu_admin == filtros.Admin.Value);
                if (filtros.Ativo.HasValue) expr = expr.And(x => x.usu_ativo == filtros.Ativo.Value);
                if (filtros.Email.HasValue()) expr = expr.And(x => x.usu_email.ToLower().Contains(filtros.Email.ToLower()));
                if (filtros.Nome.HasValue()) expr = expr.And(x => x.usu_nome.ToLower().Contains(filtros.Nome.ToLower()));
                if (filtros.Filtro.HasValue()) expr = expr.And(
                    u => Convert.ToString(u.usu_id) == filtros.Filtro ||
                    u.usu_nome.Contains(filtros.Filtro) ||
                    u.usu_email.Contains(filtros.Filtro));

            }
            return expr;
        }


    }
}
