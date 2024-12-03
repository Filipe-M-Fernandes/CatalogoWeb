using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaPrecoController : ControllerBase
    {
        private IListaPrecoService _listaPrecoService;

        public ListaPrecoController(IListaPrecoService listaPrecoService)
        {
            _listaPrecoService = listaPrecoService;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<List<ListaPreco>>> Listar()
        {
            try
            {
                return Ok(await _listaPrecoService.Listar());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
