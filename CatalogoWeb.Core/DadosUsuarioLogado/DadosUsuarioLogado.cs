using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CatalogoWeb.Core.DadosUsuarioLogado
{
    public class DadosUsuarioLogado :IDadosUsuarioLogado
    {
        private readonly IHttpContextAccessor _accessor;

        public DadosUsuarioLogado(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public int CodigoEmpresa()
        {
            Claim id = _accessor.HttpContext.User.Claims.Where(c => c.Type == "CodigoEmpresa").DefaultIfEmpty(null).FirstOrDefault();
            return Convert.ToInt32(id.Value);
        }

        public long CodigoLocal()
        {
            Claim id = _accessor.HttpContext.User.Claims.Where(c => c.Type == "CodigoLocal").DefaultIfEmpty(null).FirstOrDefault();
            return Convert.ToInt64(id.Value);
        }

        public string EmailUsuario()
        {
            Claim id = _accessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Email).DefaultIfEmpty(null).FirstOrDefault();
            return id.Value;
        }
        public long IdUsuario()
        {

            Claim id = _accessor.HttpContext.User.Claims.Where(c => c.Type == "UsuarioID").DefaultIfEmpty(null).FirstOrDefault();
            return Convert.ToInt64(id.Value);
        }

        public string NomeEmpresa()
        {
            Claim id = _accessor.HttpContext.User.Claims.Where(c => c.Type == "NomeEmpresa").DefaultIfEmpty(null).FirstOrDefault();
            return (id != null ? id.Value : null);
        }

        public string NomeFilial()
        {
            Claim id = _accessor.HttpContext.User.Claims.Where(c => c.Type == "NomeFilial").DefaultIfEmpty(null).FirstOrDefault();
            return (id != null ? id.Value : null);
        }

        public string NomeUsuario() => _accessor.HttpContext.User.Identity.Name;

    }
}
