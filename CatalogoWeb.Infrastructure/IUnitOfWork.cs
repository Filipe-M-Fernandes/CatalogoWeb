
using CatalogoWeb.Domain.Abstractions.Repositories;
using CatalogoWeb.Infrastructure.Repositories;
using CatalogWeb.Infrastructure.Context;

namespace CatalogoWeb.Infrastructure
{
    public interface IUnitOfWork
    {
        CatalogoDbContext Context { get; }
        IUsuarioRepository Usuarios { get; }
        IEmpresaRepository Empresas { get; }
        IGrupoProdutoRepository GrupoProduto { get; }
        ILocalRepository Locais { get; }
        IMarcaRepository Marcas { get; }
        INcmRepository Ncm { get; }
        IUnidadeMedidaRepository UnidadeMedida { get; }
        ISubGrupoRepository SubGrupo { get; }
        IProdutoUnidadesRepository ProdutoUnidades { get; }
        IGrupoMenuRepository GrupoMenu { get; }
        IItemMenuRepository ItemMenu { get; }
        IModalidadeGradeRepository ModalidadeGrade { get; }
        IProdutoRepository Produto { get; }
        IProdutoEstoqueRepository ProdutoEstoque { get; }
        IProdutoGradeRepository ProdutoGrade { get; }
        IListaPrecoRepository ListaPreco { get; }
        IListaPrecoItemRepository ListaPrecoItem { get; }
        Task CommitAsync();
    }
}
