using acme.sistemas.compracoletiva.domain.Interfaces.Repository;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Location;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Package;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Product;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Sales;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.User;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository.Utils;
using acme.sistemas.compracoletiva.repository;
using acme.sistemas.compracoletiva.repository.Location;
using acme.sistemas.compracoletiva.repository.Package;
using acme.sistemas.compracoletiva.repository.Product;
using acme.sistemas.compracoletiva.repository.Sales;
using acme.sistemas.compracoletiva.repository.Users;
using acme.sistemas.compracoletiva.repository.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace acme.sistemas.compracoletiva.di.Installers
{
    public static class Repositories
    {
        public static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));


            
            serviceCollection.AddTransient<IArquivoRepository, ArquivoRepository>();             
            serviceCollection.AddTransient<IConfiguracaoEmailRepository, ConfiguracaoEmailRepository>();
            serviceCollection.AddTransient<IEmailConfiguracaoEmailRepository, EmailConfiguracaoEmailRepository>();
            serviceCollection.AddTransient<IEmailRepository, EmailRepository>();
            serviceCollection.AddTransient<IEnvioEmailRepository, EnvioEmailRepository>();
            serviceCollection.AddTransient<INotificacaoRepository, NotificacaoRepository>();
            serviceCollection.AddTransient<IPagamentoRepository, PagamentoRepository>();
            serviceCollection.AddTransient<IParametroRepository, ParametroRepository>();
            serviceCollection.AddTransient<IReservaRepository, ReservaRepository>();
            serviceCollection.AddTransient<ISeguroRepository, SeguroRepository>();


            serviceCollection.AddTransient<IPessoaRepository, PessoaRepository>();
            serviceCollection.AddTransient<ITipoUsuarioRepository, TipoUsuarioRepository>();
            serviceCollection.AddTransient<IUsuarioRepository, UsuarioRepository>();


            serviceCollection.AddTransient<ICompraRepository, CompraRepository>();
            serviceCollection.AddTransient<IEncomendaRepository, EncomendaRepository>();
            serviceCollection.AddTransient<IUnidadeMedidaCompraRepository, UnidadeMedidaCompraRepository>();


            serviceCollection.AddTransient<IOfertaRepository, OfertaRepository>();
            serviceCollection.AddTransient<IProdutoRepository, ProdutoRepository>();
            serviceCollection.AddTransient<IProdutoUsuarioRepository, ProdutoUsuarioRepository>();
            serviceCollection.AddTransient<ITipoProdutoRepository, TipoProdutoRepository>();


            serviceCollection.AddTransient<IPacoteRepository, PacoteRepository>();


            serviceCollection.AddTransient<IEnderecoPessoaRepository, EnderecoPessoaRepository>();
            serviceCollection.AddTransient<IEnderecoRepository, EnderecoRepository>();

            // serviceCollection.AddTransient<IConfiguracaoTokenRepository, ConfiguracaoTokenRepository>();

            return serviceCollection;
        }
    }
}
