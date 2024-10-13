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
        public DbSet<Bairro> bairro { get; set; }
        public DbSet<Cep> cep { get; set; }
        public DbSet<Cidade> cidade { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Empresa> empresa { get; set; }
        public DbSet<Estado> estado { get; set; }
        public DbSet<Grupo> grupo { get; set; }
        public DbSet<GrupoMenu> grupoMenu { get; set; }
        public DbSet<ItemMenu> itemMenu { get; set; }
        public DbSet<ListaPreco> listaPreco { get; set; }
        public DbSet<ListaPrecoCliente> listaPrecoCliente { get; set; }
        public DbSet<ListaPrecoItem> listaPrecoItem { get; set; }
        public DbSet<ListaPrecoVendedor> listaPrecoVendedor { get; set; }
        public DbSet<Local> local { get; set; }
        public DbSet<Logradouro> logradouro { get; set; }
        public DbSet<LogradouroCidade> logradouroCidade { get; set; }
        public DbSet<Marca> marca { get; set; }
        public DbSet<ModalidadeGrade> modalidadeGrade { get; set; }
        public DbSet<Ncm> ncm { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<ParametrosEmpresa> parametrosEmpresa { get; set; }
        public DbSet<ParametrosLocal> parametrosLocal { get; set; }
        public DbSet<Pedido> pedido { get; set; }
        public DbSet<PedidoItem> pedidoItem { get; set; }
        public DbSet<PessoaEmail> pessoaEmail { get; set; }
        public DbSet<PessoaEndereco> pessoaEndereco { get; set; }
        public DbSet<PessoaFisica> pessoaFisica { get; set; }
        public DbSet<PessoaJuridica> pessoaJuridica { get; set; }
        public DbSet<PessoaTelefone> pessoaTelefone { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<ProdutoEstoque> produtoEstoque { get; set; }
        public DbSet<ProdutoGrade> produtoGrade { get; set; }
        public DbSet<ProdutoModalidadeGrade> produtoModalidadeGrade { get; set; }
        public DbSet<ProdutoUnidade> produtoUnidade { get; set; }
        public DbSet<StatusPedido> statusPedido { get; set; }
        public DbSet<SubGrupo> subGrupos { get; set; }
        public DbSet<TipoEndereco> tipoEndereco { get; set; }
        public DbSet<TipoTelefone> tipoTelefone { get; set; }
        public DbSet<UnidadeMedida> unidadeMedida { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<UsuarioAcesso> usuarioAcessos { get; set; }
        public DbSet<UsuariosLocais> usuariosLocais { get; set; }
        public DbSet<Vendedor> vendedor { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var data in entities)
            {
                var entity = data.Entity.GetType().GetProperties().Where(x => x.Name == "data_sincro").SingleOrDefault();
                if (entity != null)
                {
                    entity.SetValue(data.Entity, DateTime.Now.ToLocalTime(), null);
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BairroMap());
            modelBuilder.ApplyConfiguration(new CepMap());
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new GrupoMap());
            modelBuilder.ApplyConfiguration(new GrupoMenuMap());
            modelBuilder.ApplyConfiguration(new ItemMenuMap());
            modelBuilder.ApplyConfiguration(new LocalMap());
            modelBuilder.ApplyConfiguration(new LogradouroCidadeMap());
            modelBuilder.ApplyConfiguration(new LogradouroMap());
            modelBuilder.ApplyConfiguration(new ListaPrecoMap());
            modelBuilder.ApplyConfiguration(new ListaPrecoItemMap());
            modelBuilder.ApplyConfiguration(new ListaPrecoClienteMap());
            modelBuilder.ApplyConfiguration(new ListaPrecoVendedorMap());
            modelBuilder.ApplyConfiguration(new NcmMap());
            modelBuilder.ApplyConfiguration(new NcmMap());
            modelBuilder.ApplyConfiguration(new MarcaMap());
            modelBuilder.ApplyConfiguration(new ModalidadeGradeMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ProdutoEstoqueMap());
            modelBuilder.ApplyConfiguration(new ProdutoGradeMap());
            modelBuilder.ApplyConfiguration(new ProdutoModalidadeGradeMap());
            modelBuilder.ApplyConfiguration(new ParametrosEmpresaMap());
            modelBuilder.ApplyConfiguration(new ParametrosLocalMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new PedidoItemMap());
            modelBuilder.ApplyConfiguration(new PessoaEnderecoMap());
            modelBuilder.ApplyConfiguration(new PessoaTelefoneMap());
            modelBuilder.ApplyConfiguration(new PessoaEmailMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new PessoaFisicaMap());
            modelBuilder.ApplyConfiguration(new PessoaJuridicaMap());
            modelBuilder.ApplyConfiguration(new SubGrupoMap());
            modelBuilder.ApplyConfiguration(new StatusPedidoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuariosLocaisMap());
            modelBuilder.ApplyConfiguration(new UnidadeMedidaMap());
            modelBuilder.ApplyConfiguration(new UsuarioAcessoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
