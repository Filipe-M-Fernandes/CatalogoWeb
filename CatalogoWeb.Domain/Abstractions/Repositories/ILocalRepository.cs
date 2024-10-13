using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Abstractions.Repositories;

public interface ILocalRepository : IRepositoryBase<Local, long>
{
    Task<Local> WhereLocalIncludeEmpresa(int empId, long locId);
}