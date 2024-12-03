using CatalogoWeb.Core.DadosUsuarioLogado;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Abstractions.Services;
using CatalogoWeb.Domain.Profiles;
using CatalogoWeb.Infrastructure;
using CatalogoWeb.Infrastructure.Context;
using CatalogoWeb.Infrastructure.Repositories;
using CatalogoWeb.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.ComponentModel.Design;
using XAct.IO;

namespace CatalogoWeb.Api.Extensions
{
    public static partial class ServiceInitializer
    {
        public static IServiceCollection RegistrarApplicationServices(this IServiceCollection services)
        {
            RegistrarAutoMapper(services);
            RegistrarServicos(services);
            RegistrarRepositorios(services);
            return services;
        }
        private static void RegistrarRepositorios(IServiceCollection services)
        {
            services.TryAddScoped<IEmpresaRepository, EmpresaRepository>();
            services.TryAddScoped<IGrupoProdutoRepository, GrupoProdutoRepository>();
            services.TryAddScoped<IListaPrecoRepository, ListaPrecoRepository>();
            services.TryAddScoped<IListaPrecoItemRepository, ListaPrecoItemRepository>();
            services.TryAddScoped<ILocalRepository, LocalRepository>();
            services.TryAddScoped<IMarcaRepository, MarcaRepository>();
            services.TryAddScoped<IModalidadeGradeRepository, ModalidadeGradeRepository>();
            services.TryAddScoped<INcmRepository, NcmRepository>();
            services.TryAddScoped<IProdutoEstoqueRepository, ProdutoEstoqueRepository>();
            services.TryAddScoped<IProdutoModalidadeGradeRepository, ProdutoModalidadeGradeRepository>();
            services.TryAddScoped<IProdutoGradeRepository, ProdutoGradeRepository>();
            services.TryAddScoped<IProdutoRepository, ProdutoRepository>();
            services.TryAddScoped<ISubGrupoRepository, SubGrupoRepository>();
            services.TryAddScoped<IUnidadeMedidaRepository, UnidadeMedidaRepository>();
            services.TryAddScoped<IUsuarioRepository, UsuarioRepository>();
            services.TryAddScoped<IUsuariosLocaisRepository, UsuariosLocaisRepository>();
        }

        private static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<IDadosUsuarioLogado, DadosUsuarioLogado>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.TryAddScoped<IEmpresaService, EmpresaService>();
            services.TryAddScoped<ILocalService, LocalService>();
            services.TryAddScoped<IMarcaService, MarcaService>();
            services.TryAddScoped<IEnviaEmailService, EnviaEmailService>();
            services.TryAddScoped<ILoginService, LoginService>();
            services.TryAddScoped<ISubGrupoService, SubGrupoService>();
            services.TryAddScoped<IClienteService, ClienteService>();
            services.TryAddScoped<IProdutoService, ProdutoService>();
            services.TryAddScoped<IGrupoService, GrupoService>();
            services.TryAddScoped<IImagemService, ImagemService>();
            services.TryAddScoped<IUsuarioService, UsuarioService>();
            services.TryAddScoped<IAvatarService, AvatarService>();
            services.TryAddScoped<IAcessosService, AcessosService>();
            services.TryAddScoped<IProdutoGradeService, ProdutoGradeService>();
            services.TryAddScoped<IUnidadeMedidaService, UnidadeMedidaService>();
            services.TryAddScoped<IListaPrecoService, ListaPrecoService>();
            services.TryAddScoped<IListaPrecoItemService, ListaPrecoItemService>();

        }

        private static void RegistrarAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
        }
    }
}
