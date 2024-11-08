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
            //services.TryAddScoped<IBairroRepository, BairroRepository>();
            //services.TryAddScoped<ICepRepository, CepRepository>();
            //services.TryAddScoped<IClienteRepository, ClienteRepository>();
            //services.TryAddScoped<ICidadeRepository, CidadeRepository>();
            services.TryAddScoped<IEmpresaRepository, EmpresaRepository>();
            //services.TryAddScoped<IEstadoRepository, EstadoRepository>();
            services.TryAddScoped<IGrupoProdutoRepository, GrupoProdutoRepository>();
            services.TryAddScoped<IListaPrecoClienteRepository, ListaPrecoClienteRepository>();
            services.TryAddScoped<IListaPrecoRepository, ListaPrecoRepository>();
            services.TryAddScoped<IListaPrecoItemRepository, ListaPrecoItemRepository>();
            services.TryAddScoped<ILocalRepository, LocalRepository>();
            //services.TryAddScoped<ILogradouroCidadeRepository, LogradouroCidadeRepository>();
            //services.TryAddScoped<ILogradouroRepository, LogradouroRepository>();
            services.TryAddScoped<IMarcaRepository, MarcaRepository>();
            services.TryAddScoped<IModalidadeGradeRepository, ModalidadeGradeRepository>();
            services.TryAddScoped<INcmRepository, NcmRepository>();
            //services.TryAddScoped<IPaisRepository, PaisRepository>();
            //services.TryAddScoped<IParametrosEmpresaRepository, ParametrosEmpresaRepository>();
            //services.TryAddScoped<IParametrosLocalRepository, ParametrosLocalRepository>();
            //services.TryAddScoped<IPedidoRepository, PedidoRepository>();
            //services.TryAddScoped<IPedidoItemRepository, PedidoItemRepository>();
            //services.TryAddScoped<IPessoaRepository, PessoaRepository>();
            //services.TryAddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
            //services.TryAddScoped<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
            //services.TryAddScoped<IPessoaEnderecoRepository, PessoaEnderecoRepository>();
            //services.TryAddScoped<IPessoaEmailRepository, PessoaEmailRepository>();
            //services.TryAddScoped<IPessoaTelefoneRepository, PessoaTelefoneRepository>();
            services.TryAddScoped<IProdutoEstoqueRepository, ProdutoEstoqueRepository>();
            services.TryAddScoped<IProdutoModalidadeGradeRepository, ProdutoModalidadeGradeRepository>();
            services.TryAddScoped<IProdutoGradeRepository, ProdutoGradeRepository>();
            services.TryAddScoped<IProdutoRepository, ProdutoRepository>();
            //services.TryAddScoped<IStatusPedidoRepository, StatusPedidoRepository>();
            services.TryAddScoped<ISubGrupoRepository, SubGrupoRepository>();
            //services.TryAddScoped<ITipoEnderecoRepository, TipoEnderecoRepository>();
            //services.TryAddScoped<ITipoTelefoneRepository, TipoTelefoneRepository>();
            services.TryAddScoped<IUnidadeMedidaRepository, UnidadeMedidaRepository>();
            services.TryAddScoped<IUsuarioRepository, UsuarioRepository>();
            services.TryAddScoped<IUsuariosLocaisRepository, UsuariosLocaisRepository>();
            //services.TryAddScoped<IVendedorRepository, VendedorRepository>();
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

        }

        private static void RegistrarAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
        }
    }
}
