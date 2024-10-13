using AutoMapper;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure.Repositories;
using CatalogWeb.Infrastructure.Context;
using System.Numerics;

namespace CatalogoWeb.Infrastructure.Context
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public CatalogoDbContext Context { get; private set; }
        public IBairroRepository Bairros { get; private set; }
        public ICidadeRepository Cidades { get; private set; }
        public ICepRepository Ceps { get; private set; }
        public IUsuarioRepository Usuarios { get; private set; }
        public IEmpresaRepository Empresas { get; private set; }
        public IEstadoRepository Estados { get; private set; }
        public IGrupoProdutoRepository GrupoProduto { get; private set; }
        public ILocalRepository Locais { get; private set; }
        public IMarcaRepository Marcas { get; private set; }
        public IUnidadeMedidaRepository UnidadeMedida { get; private set; }
        public INcmRepository Ncm { get; private set; }
        public IStatusPedidoRepository StatusPedido { get; private set; }
        public ISubGrupoRepository SubGrupo { get; private set; }
        public ILogradouroRepository Logradouro { get; private set; }
        public ILogradouroCidadeRepository LogradouroCidade { get; private set; }
        public IParametrosEmpresaRepository ParametrosEmpresa { get; private set; }
        public IParametrosLocalRepository ParametrosLocal { get; private set; }
        public IPessoaRepository Pessoa { get; private set; }
        public IPessoaFisicaRepository PessoaFisica { get; private set; }
        public IPessoaJuridicaRepository PessoaJuridica { get; private set; }
        public IPessoaEmailRepository PessoaEmail { get; private set; }
        public IPessoaTelefoneRepository PessoaTelefone { get; private set; }
        public IPessoaEnderecoRepository PessoaEndereco { get; private set; }
        public IPaisRepository Pais { get; private set; }
        public IClienteRepository Cliente { get; private set; }
        public IGrupoMenuRepository GrupoMenu { get; private set; }
        public IItemMenuRepository ItemMenu { get; private set; }
        public IVendedorRepository Vendedor { get; private set; }
        public ITipoTelefoneRepository TipoTelefone { get; private set; }
        public ITipoEnderecoRepository TipoEndereco { get; private set; }
        public IProdutoRepository Produto { get; private set; }
        public IProdutoUnidadesRepository ProdutoUnidades { get; private set; }
        public IProdutoEstoqueRepository ProdutoEstoque { get; private set; }
        public IProdutoGradeRepository ProdutoGrade { get; private set; }
        public IListaPrecoRepository ListaPreco { get; private set; }
        public IListaPrecoItemRepository ListaPrecoItem { get; private set; }
        public IPedidoRepository Pedido { get; private set; }
        public IPedidoItemRepository PedidoItem { get; private set; }
        public IModalidadeGradeRepository ModalidadeGrade { get; private set; }

        public UnitOfWork(CatalogoDbContext context, IMapper mapper)
        {
            Context = context;
            Bairros = new BairroRepository(Context, mapper);
            Cidades = new CidadeRepository(Context, mapper);
            Ceps = new CepRepository(Context, mapper);
            Cliente = new ClienteRepository(Context, mapper);
            Empresas = new EmpresaRepository(Context, mapper);
            Estados = new EstadoRepository(Context, mapper);
            GrupoProduto = new GrupoProdutoRepository(Context, mapper);
            Locais = new LocalRepository(Context, mapper);
            Logradouro = new LogradouroRepository(Context, mapper);
            LogradouroCidade = new LogradouroCidadeRepository(Context, mapper);
            Marcas = new MarcaRepository(Context, mapper);
            Ncm = new NcmRepository(Context, mapper);
            ParametrosEmpresa = new ParametrosEmpresaRepository(Context, mapper);
            ParametrosLocal = new ParametrosLocalRepository(Context, mapper);
            Pessoa = new PessoaRepository(Context, mapper);
            PessoaFisica = new PessoaFisicaRepository(Context, mapper);
            PessoaJuridica = new PessoaJuridicaRepository(Context, mapper);
            PessoaEmail = new PessoaEmailRepository(Context, mapper);
            PessoaTelefone = new PessoaTelefoneRepository(Context, mapper);
            PessoaEndereco = new PessoaEnderecoRepository(Context, mapper);
            Pais = new PaisRepository(Context, mapper);
            StatusPedido = new StatusPedidoRepository(Context, mapper);
            SubGrupo = new SubGrupoRepository(Context, mapper);
            TipoTelefone = new TipoTelefoneRepository(Context, mapper);
            Usuarios = new UsuarioRepository(Context, mapper);
            UnidadeMedida = new UnidadeMedidaRepository(Context, mapper);
            Usuarios = new UsuarioRepository(Context, mapper);
            UnidadeMedida = new UnidadeMedidaRepository(Context, mapper);
            GrupoMenu = new GrupoMenuRepository(Context, mapper);
            ItemMenu = new ItemMenuRepository(Context, mapper);
            ModalidadeGrade = new ModalidadeGradeRepository(Context, mapper);
            Vendedor = new VendedorRepository(Context, mapper);
            TipoEndereco = new TipoEnderecoRepository(Context, mapper);
            Produto = new ProdutoRepository(Context, mapper);
            ProdutoEstoque = new ProdutoEstoqueRepository(Context, mapper);
            ProdutoGrade = new ProdutoGradeRepository(Context, mapper);
            ListaPreco = new ListaPrecoRepository(Context, mapper);
            ListaPrecoItem = new ListaPrecoItemRepository(Context, mapper);
            Pedido = new PedidoRepository(Context, mapper);
            PedidoItem = new PedidoItemRepository(Context, mapper);
            ModalidadeGrade = new ModalidadeGradeRepository(Context, mapper);
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}