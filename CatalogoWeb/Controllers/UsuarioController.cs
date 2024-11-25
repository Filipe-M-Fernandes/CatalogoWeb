using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using CatalogoWeb.Domain.Abstractions.Services;
using System.Net;

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
    }
}
