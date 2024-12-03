using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaPrecoItemController : ControllerBase
    {
        private IListaPrecoItemService _listaPrecoItemService;
        public ListaPrecoItemController(IListaPrecoItemService listaPrecoItemService)
        {
            _listaPrecoItemService = listaPrecoItemService;
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<List<ListaPrecoItem>>> Listar([FromQuery] long proId)
        {
            try
            {
                return Ok(await _listaPrecoItemService.Listar(proId));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
