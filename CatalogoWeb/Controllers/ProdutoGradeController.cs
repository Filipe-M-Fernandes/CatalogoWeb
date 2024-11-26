using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoGradeController : ControllerBase
    {
        private IProdutoGradeService _produtoGradeService;
        public ProdutoGradeController(IProdutoGradeService produtoGradeService)
        {
            _produtoGradeService = produtoGradeService;
        }

        [HttpGet("BuscarGradesProdutos")]
        public async Task<ActionResult<List<ProdutoGrade>>> BuscarGradeProduto([FromQuery] int produtoId)
        {
            try
            {
                return Ok(await _produtoGradeService.BuscarGradeProduto(produtoId));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
