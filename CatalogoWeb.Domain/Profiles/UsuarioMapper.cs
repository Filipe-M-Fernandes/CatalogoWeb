﻿using AutoMapper;
using CatalogoWeb.Domain.DTO;
using CatalogoWeb.Domain.Entidades;

namespace CatalogoWeb.Domain.Profiles
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}