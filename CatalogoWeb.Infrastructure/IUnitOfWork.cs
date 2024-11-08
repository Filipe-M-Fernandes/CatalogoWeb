using CatalogoWeb.Abstractions.Repositories;
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Infrastructure.Repositories;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure
{
    public interface IUnitOfWork
    {
        CatalogoDbContext Context { get; }
        //IBairroRepository Bairros { get; }
        //ICidadeRepository Cidades { get; }
        //ICepRepository Ceps { get; }
        IUsuarioRepository Usuarios { get; }
        //IEstadoRepository Estados { get; }
        IEmpresaRepository Empresas { get; }
        IGrupoProdutoRepository GrupoProduto { get; }
        ILocalRepository Locais { get; }
        IMarcaRepository Marcas { get; }
        INcmRepository Ncm { get; }
        IUnidadeMedidaRepository UnidadeMedida { get; }
        //IStatusPedidoRepository StatusPedido { get; }
        ISubGrupoRepository SubGrupo { get; }
        //ILogradouroCidadeRepository LogradouroCidade { get; }
        //ILogradouroRepository Logradouro { get; }
        //IParametrosEmpresaRepository ParametrosEmpresa { get; }
        IProdutoUnidadesRepository ProdutoUnidades { get; }
        //IParametrosLocalRepository ParametrosLocal { get; }
        //IPessoaRepository Pessoa { get; }
        //IPessoaFisicaRepository PessoaFisica { get; }
        //IPessoaJuridicaRepository PessoaJuridica { get; }
        //IPessoaEmailRepository PessoaEmail { get; }
        //IPessoaTelefoneRepository PessoaTelefone { get; }
        //IPessoaEnderecoRepository PessoaEndereco { get; }
        //IPaisRepository Pais { get; }
        //IClienteRepository Cliente { get; }
        IGrupoMenuRepository GrupoMenu { get; }
        IItemMenuRepository ItemMenu { get; }
        IModalidadeGradeRepository ModalidadeGrade { get; }
        //IVendedorRepository Vendedor { get; }
        //ITipoTelefoneRepository TipoTelefone { get; }
        //ITipoEnderecoRepository TipoEndereco { get; }
        IProdutoRepository Produto { get; }
        IProdutoEstoqueRepository ProdutoEstoque { get; }
        IProdutoGradeRepository ProdutoGrade { get; }
        IListaPrecoRepository ListaPreco { get; }
        IListaPrecoItemRepository ListaPrecoItem { get; }
        //IPedidoRepository Pedido { get; }
        //IPedidoItemRepository PedidoItem { get; }
        //IUsuarioAcessoRepository UsuarioAcesso { get; }
        Task CommitAsync();
    }
}
