using acme.sistemas.compracoletiva.service.Handlers.Reserva.Handler;
using acme.sistemas.compracoletiva.service.Interfaces.Service;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Location;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Package;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Product;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Sales;
using acme.sistemas.compracoletiva.service.Interfaces.Service.User;
using acme.sistemas.compracoletiva.service.Interfaces.Service.Utils;
using acme.sistemas.compracoletiva.service.Service;
using acme.sistemas.compracoletiva.service.Service.Location;
using acme.sistemas.compracoletiva.service.Service.Package;
using acme.sistemas.compracoletiva.service.Service.Product;
using acme.sistemas.compracoletiva.service.Service.Sales;
using acme.sistemas.compracoletiva.service.Service.Users;
using acme.sistemas.compracoletiva.service.Service.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace acme.sistemas.compracoletiva.di.Installers
{
    public static class DomainServices
    {
        public static IServiceCollection InstallDomainServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));


            serviceCollection.AddTransient<IArquivoService, ArquivoService>();
            serviceCollection.AddTransient<IConfiguracaoEmailService, ConfiguracaoEmailService>();
            serviceCollection.AddTransient<IEmailConfiguracaoEmailService, EmailConfiguracaoEmailService>();
            serviceCollection.AddTransient<IEmailService, EmailService>();
            serviceCollection.AddTransient<IEnvioEmailService, EnvioEmailService>();
            serviceCollection.AddTransient<INotificacaoService, NotificacaoService>();
            serviceCollection.AddTransient<IPagamentoService, PagamentoService>();
            serviceCollection.AddTransient<IParametroService, ParametroService>();
            serviceCollection.AddTransient<CriaReservaHandle>();
            serviceCollection.AddTransient<ISeguroService, SeguroService>();


            serviceCollection.AddTransient<IPessoaService, PessoaService>();
            serviceCollection.AddTransient<ITipoUsuarioService, TipoUsuarioService>();
            serviceCollection.AddTransient<IUsuarioService, UsuarioService>();


            serviceCollection.AddTransient<ICompraService, CompraService>();
            serviceCollection.AddTransient<IEncomendaService, EncomendaService>();
            serviceCollection.AddTransient<IUnidadeMedidaCompraService, UnidadeMedidaCompraService>();


            serviceCollection.AddTransient<IOfertaService, OfertaService>();
            serviceCollection.AddTransient<IProdutoService, ProdutoService>();
            serviceCollection.AddTransient<IProdutoUsuarioService, ProdutoUsuarioService>();
            serviceCollection.AddTransient<ITipoProdutoService, TipoProdutoService>();


            serviceCollection.AddTransient<IPacoteService, PacoteService>();


            serviceCollection.AddTransient<IEnderecoPessoaService, EnderecoPessoaService>();
            serviceCollection.AddTransient<IEnderecoService, EnderecoService>();


            //serviceCollection.AddTransient<IConfiguracaoTokenServices, ConfiguracaoTokenServices>();
            return serviceCollection;
        }
    }
}
