using acme.sistemas.compracoletiva.core.Base;
using acme.sistemas.compracoletiva.domain.Entity.Location;
using acme.sistemas.compracoletiva.domain.Entity.Notifications;
using acme.sistemas.compracoletiva.domain.Entity.Package;
using acme.sistemas.compracoletiva.domain.Entity.Product;
using acme.sistemas.compracoletiva.domain.Entity.Sales;
using acme.sistemas.compracoletiva.domain.Entity.Security;
using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.domain.Entity.Utils;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace acme.sistemas.compracoletiva.infra.Config
{
    public class Context : IdentityDbContext<Usuario, Permissao, Guid, UserClaim, PermissaoUsuario, UserLogin, PermissaoClaim, UserToken>
    {

        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Endereco> Enderecos { get; private set; }
        public DbSet<EnderecoPessoa> EnderecosPessoas { get; private set; }

        public DbSet<BaseNotification> BaseNotifictions { get; private set; }
        public DbSet<Notification> Notifications { get; private set; }

        public DbSet<Pacote> Pacotes { get; private set; }

        public DbSet<Oferta> Ofertas { get; private set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoUsuario> ProdutoUsuarios { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }


        public DbSet<Compra> Compras { get; private set; }
        public DbSet<CompraProduto> CompraProdutos { get; private set; }
        public DbSet<Encomenda> Encomendas { get; private set; }
        public DbSet<UnidadeMedidaCompra> UnidadeMedidaCompra { get; set; }


        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }


        public DbSet<Seguro> Seguros { get; private set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Notificacao> Notificacaos { get; private set; }
        public DbSet<Pagamento> Pagamentos { get; private set; }
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<EnderecoPessoa> EnderecosPessoa { get; set; }
        public DbSet<Parametro> Parametros { get; set; }


        public DbSet<Email> Emails { get; private set; }
        public DbSet<EnvioEmail> EnvioEmails { get; private set; }
        public DbSet<EmailConfiguracaoEmail> EmailConfiguracaoEmails { get; private set; }

        public DbSet<ConfiguracaoToken> ConfiguracaoTokens { get; set; }
        public DbSet<ConfiguracaoTokenSistema> ConfiguracaoTokenSistemas { get; set; }

        public override DbSet<Usuario> Users { get; set; }
        public override DbSet<Permissao> Roles { get; set; }
        public override DbSet<PermissaoUsuario> UserRoles { get; set; }

        public override DbSet<PermissaoClaim> RoleClaims { get; set; }
        public override DbSet<UserClaim> UserClaims { get; set; }
        public override DbSet<UserLogin> UserLogins { get; set; }
        public override DbSet<UserToken> UserTokens { get; set; }

        public async Task<bool> Commit()
        {
           return await this.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            var stringProperties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(_ => _.GetProperties())
                .Where(_ => _.ClrType == typeof(string) && _.GetColumnType() == null);

            foreach (var item in stringProperties)
            {
                item.SetIsUnicode(false);
                if (item.GetMaxLength() == null)
                    item.SetMaxLength(256);
            }

            var decimalProperties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(_ => _.GetProperties())
                .Where(_ => (_.ClrType == typeof(decimal) || _.ClrType == typeof(decimal?)) && _.GetColumnType() == null);

            foreach (var item in decimalProperties)
            {
                if (item.GetPrecision() == null && item.GetScale() == null)
                {
                    item.SetPrecision(18);
                    item.SetScale(4);
                }
            }
            modelBuilder.Entity<Permissao>().ToTable("Permissao").HasKey(t => t.Id);
            modelBuilder.Entity<PermissaoClaim>().ToTable("PermissaoClaim").HasKey(t => t.Id);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim").HasKey(t => t.Id);
            modelBuilder.Entity<PermissaoUsuario>().ToTable("UserPermissao").HasKey(t => t.Id);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin").HasKey(t => t.Id);
            modelBuilder.Entity<UserToken>().ToTable("UserToken").HasKey(t => t.Id);


            base.OnModelCreating(modelBuilder);
        }

    }
}
