using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using CatalogoWeb.Domain.Abstractions.Services;
using System.Net;
using CatalogoWeb.Domain.DTO.Command.Usuario;
using Microsoft.AspNetCore.Authorization;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<PagedModel<Usuario>>> BuscarTodos([FromQuery] FiltrosUsuarios filtros, [FromQuery] PagedParams paginacao)
        {
            try
            {
                return Ok(await _usuarioService.BuscarTodos(filtros, paginacao));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("Incluir")]
        public async Task<ActionResult<bool>> Incluir([FromBody] UsuarioInsertCommand usu)
        {
            try
            {
                return Ok(await _usuarioService.Incluir(usu));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("AtivarUsuario"), AllowAnonymous]
        public async Task<ActionResult<bool>> AtivarUsuario(UsuarioNovaSenhaCommand usuario)
        {
            try
            {
                return Ok(await _usuarioService.AlterarSenha(usuario));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("RetornaUsuarioEmail"), AllowAnonymous]
        public async Task<ActionResult<UsuarioDTO>> GetRetornaUsuarioEmail(string email)
        {
            try
            {
                return await _usuarioService.RetornaUsuarioEmail(email);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPut("Editar")]
        public async Task<ActionResult<UsuarioDTO>> PostEditar(UsuarioUpdateCommand user)
        {
            try
            {
                return Ok(await _usuarioService.Editar(user));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
