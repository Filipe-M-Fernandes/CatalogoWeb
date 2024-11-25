using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.Entidades.Filtros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatalogoWeb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private IProdutoService _produtoService;
        private IDadosUsuarioLogado _dadosUsuarioLogado;
        public ProdutoController(IProdutoService produtoService, IDadosUsuarioLogado dadosUsuarioLogado)
        {
            _produtoService = produtoService;
            _dadosUsuarioLogado = dadosUsuarioLogado;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> PopularProdutos([FromBody] List<PopularProdutoDTO> dados)
        {
            try
            {
                var ret = await _produtoService.PopularDados(dados);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult<PagedModel<Produto>>> Listar([FromQuery] FiltrosProdutoListarTodos filtros, [FromQuery] PagedParams paginacao)
        {
            try
            {
                var ret = await _produtoService.ListarTodas(filtros, paginacao);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<ActionResult<bool>> AtualiarDados([FromBody] List<PopularProdutoDTO> dados)
        {
            try
            {
                var ret = await _produtoService.AtualizarDadosGerados(dados);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
