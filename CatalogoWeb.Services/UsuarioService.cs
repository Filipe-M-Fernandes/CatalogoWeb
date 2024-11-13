using AutoMapper;
using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.DTO.Command.Usuario;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure;
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

        public async Task<Usuario> BuscarAsync(long id)
        {
            return await _unitOfWork.Usuarios.GetByIdAsync(id);
        }

        public async Task<UsuarioDTO> Incluir(UsuarioInsertCommand dados)
        {
            Usuario entidade = _mapper.Map<Usuario>(dados);

            entidade.usu_avatar = await _avatarService.InserirAvatar(dados.usu_email, dados.avatar);
            //entidade = CriarVinculoUsuarioEmpresa(entidade);
            entidade.usu_datainclusao = DateTime.Today;
            entidade.usu_ultimologin = DateTime.Today;

            if (dados.usu_senha != null) entidade.usu_senha = await ConfirmarTrocaSenha(dados.usu_senha);

            UsuarioDTO retorno = await IncluirAsync(entidade);

            // if (dados.listaPermissoesPaginas != null) await _permissaoUsuario.AtribuirPermissoesParaUsuario(retorno.usu_id, dados.listaPermissoesPaginas);

            await EnviarEmailAtivacaoUsuario(retorno.usu_email, retorno.usu_nome);

            return retorno;
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

            #region Conteúdo do email em HTML
            string conteudoCorpoEmail = $@"
            
<html xmlns=""http://www.w3.org/1999/xhtml"">
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
            <tr>
                <td colspan=""3"" align=""right"" background=""https://app.gestorweb.com.br/templateEmails/img/bg-topo.png"" style=""width: 550px; height: 305px; vertical-align: bottom; background-repeat: no-repeat !important; overflow: hidden;"">
                    <!--[if gte mso 9]>
                     <v:rect xmlns:v=""urn:schemas-microsoft-com:vml"" fill=""true"" stroke=""false"" style=""width:550px; height:259px; background-repeat:no-repeat !important;"">
                         <v:fill type=""tile"" src=""https://app.gestorweb.com.br/templateEmails/img/bg-topo.png"" />
                         <v:textbox inset=""0,0,0,0"">
                         <![endif]-->
                    <div>
                        <p style=""margin: 0;"">
                            <font face=""Helvetica, Arial, sans-serif"" color=""#ffffff"" style=""font-size: 24px;"">
                                <b> Seja muito&nbsp;&nbsp; </b>
                            </font>
                        </p>
                        <p style=""margin: 0;"">
                            <font face=""Helvetica, Arial, sans-serif"" color=""#ffffff"" style=""font-size: 32px;"">
                                <b> bem vindo(a) </b>
                            </font>
                            <font face=""Helvetica, Arial, sans-serif"" color=""#ffffff"" style=""font-size: 24px;"">
                                <b> ao&nbsp;</b>
                            </font>
                            <br /> <br /> <br />
                        </p>
                    </div>
                    <!--[if gte mso 9]>
                          </v:textbox>
                      </v:rect>
                    <![endif]-->
                </td>
            </tr>
            <tr bgcolor=""#ffffff"">
                <td colspan=""3"" height=""10""></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td align=""center"">
                    <img src=""https://app.gestorweb.com.br/templateEmails/img/img-logo.png"" width=""190"" height=""56"" alt=""Gestor Web"">
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
                                <a href=""{linkAtivacaoContaUsuario}"" target=""_blank"" style=""font-size: 22px; padding: 15px 30px; background-color: #14a3b3;"">
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
                        <tr bgcolor=""#0053a6"">
                            <td colspan=""3"" align=""left"" style=""padding: 30px;"">
                                <div style=""text-align: center;"">
                                    <font face=""Helvetica, Arial, sans-serif"" color=""#ffffff"" style=""font-size: 25px;"">
                                        <b><i>Somos diferentes</i></b>
                                    </font>
                                </div>
                                
                                <div>
                                    <font face=""Helvetica, Arial, sans-serif"" color=""#ffffff"" style=""font-size: 12px;text-align: right; width: 100%; display: inline-block;"">
                                        Atenciosamente
                                        <br />
                                        Equipe Gestor Web
                                    </font>
                                    </p>
                            </td>
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

            await _enviaEmailService.EnviaEmail(email, "Bem vindo ao Catalogo Web!", conteudoCorpoEmail, true);

        }

    }
}
