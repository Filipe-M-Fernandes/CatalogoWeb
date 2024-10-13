using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure.Context;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWeb.Infrastructure.Repositories
{
    public class UsuariosLocaisRepository : RepositoryBase<UsuariosLocais, long>, IUsuariosLocaisRepository
    {
        public UsuariosLocaisRepository(CatalogoDbContext context, ILogger<UsuariosLocais> logger, IMapper mapper) : base(context, mapper) {}

    }
}
