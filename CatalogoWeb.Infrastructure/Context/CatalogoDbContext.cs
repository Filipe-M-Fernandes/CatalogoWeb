using CatalogoWeb.Domain.Entidades;
using CatalogoWeb.Infrastructure.Maps;
using Microsoft.EntityFrameworkCore;

namespace CatalogWeb.Infrastructure.Context
{
    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<Empresa> empresa { get; set; }
        public DbSet<Grupo> grupo { get; set; }
        public DbSet<GrupoMenu> grupoMenu { get; set; }
        public DbSet<ItemMenu> itemMenu { get; set; }
        public DbSet<ListaPreco> listaPreco { get; set; }
        public DbSet<ListaPrecoItem> listaPrecoItem { get; set; }
        public DbSet<Local> local { get; set; }
        public DbSet<Marca> marca { get; set; }
        public DbSet<ModalidadeGrade> modalidadeGrade { get; set; }
        public DbSet<Ncm> ncm { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<ProdutoEstoque> produtoEstoque { get; set; }
        public DbSet<ProdutoGrade> produtoGrade { get; set; }
        public DbSet<ProdutoModalidadeGrade> produtoModalidadeGrade { get; set; }
        public DbSet<ProdutoUnidade> produtoUnidade { get; set; }
        public DbSet<SubGrupo> subGrupos { get; set; }
        public DbSet<UnidadeMedida> unidadeMedida { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<UsuariosLocais> usuariosLocais { get; set; }
        public DbSet<ImagemProduto> imagemProduto { get; set; }
        public DbSet<ProdutosAcesso> produtosAcesso { get; set; }
        public DbSet<GruposAcesso> gruposAcesso { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new GrupoMap());
            modelBuilder.ApplyConfiguration(new GrupoMenuMap());
            modelBuilder.ApplyConfiguration(new ItemMenuMap());
            modelBuilder.ApplyConfiguration(new LocalMap());
            modelBuilder.ApplyConfiguration(new ListaPrecoMap());
            modelBuilder.ApplyConfiguration(new ListaPrecoItemMap());
            modelBuilder.ApplyConfiguration(new NcmMap());
            modelBuilder.ApplyConfiguration(new MarcaMap());
            modelBuilder.ApplyConfiguration(new ModalidadeGradeMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ProdutoEstoqueMap());
            modelBuilder.ApplyConfiguration(new ProdutoGradeMap());
            modelBuilder.ApplyConfiguration(new ProdutoModalidadeGradeMap());
            modelBuilder.ApplyConfiguration(new SubGrupoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuariosLocaisMap());
            modelBuilder.ApplyConfiguration(new UnidadeMedidaMap());
            modelBuilder.ApplyConfiguration(new ProdutoUnidadeMap());
            modelBuilder.ApplyConfiguration(new ImagemProdutoMap());
            modelBuilder.ApplyConfiguration(new ProdutosAcessoMap());
            modelBuilder.ApplyConfiguration(new GruposAcessoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
