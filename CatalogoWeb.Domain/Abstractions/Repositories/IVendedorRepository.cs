using CatalogoWeb.Domain.DTO.Query;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Domain.Entidades.Filtros;
using CatalogoWeb.Domain.Entidades.Filtros.Vendedor;

namespace CatalogoWeb.Domain.Abstractions.Repositories;

public interface IVendedorRepository : IRepositoryBase<Vendedor, long>
{

}
