using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure.Context;
using AutoMapper;
using iText.Commons.Actions.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWeb.Infrastructure.Repositories
{
    public class ListaPrecoClienteRepository : RepositoryBase<ListaPrecoCliente, long>, IListaPrecoClienteRepository
    {
        public ListaPrecoClienteRepository(CatalogoDbContext context, IMapper mapper) : base(context, mapper) { }
       
    }
}
