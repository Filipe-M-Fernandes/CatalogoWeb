using CatalogoWeb.Api.Authorization;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private IConfiguration _configuration;
        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("EfetuarLogin")]
        public async Task<ActionResult<string>> EfetuarLogin([FromBody] Login lg)
        {
            try
            {
                UsuarioDTO usuario = await _loginService.AutenticarAsync(lg);
                if (usuario == null)
                    return Unauthorized("Usuário ou Senha Incorretos. Tente Novamente!");
                if (usuario.usu_ativo == false)
                    return Unauthorized("Usuário Bloqueado!");
                var tokenService = new TokenService(_configuration.GetSection("JWT"));
                return Ok(tokenService.GenerateToken(usuario));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
