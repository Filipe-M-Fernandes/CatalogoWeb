using CatalogoWeb.Core;
using CatalogoWeb.Domain.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CatalogoWeb.Api.Authorization
{
    public class TokenService
    {
        private IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(UsuarioDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration[nameof(JwtOptions.Secret)])), SecurityAlgorithms.HmacSha256),
                Subject = GetClaimsIdentity(user)
            });
            return tokenHandler.WriteToken(tokenDescriptor);
        }
        private ClaimsIdentity GetClaimsIdentity(UsuarioDTO user)
        {
            return new ClaimsIdentity(
                new[] {
                        new Claim ("UsuarioID", user.usu_id.ToString()),
                        new Claim (ClaimTypes.Name,  TextoHelper.RemoverCaracteresEspeciais(TextoHelper.RemoverAcentos(user.usu_nome))),
                        new Claim (ClaimTypes.Email, user.usu_email),
                        new Claim (ClaimTypes.Role, (user.usu_admin == true)  ? "Admin" : "Usuario"),
                        new Claim ("CodigoEmpresa", (user.emp_id ?? 0).ToString()),
                        new Claim ("NomeEmpresa", user.emp_nomefantasia?? ""),
                        new Claim ("CodigoLocal", (user.loc_id?? 0).ToString()),
                        new Claim ("NomeFilial", user.loc_descricao??""),
                }
            );
        }
        
    }
}
