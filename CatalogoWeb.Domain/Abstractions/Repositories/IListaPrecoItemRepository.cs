﻿using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoWeb.Domain.Abstractions.Repositories;

public interface IListaPrecoItemRepository : IRepositoryBase<ListaPrecoItem, long>
{
}