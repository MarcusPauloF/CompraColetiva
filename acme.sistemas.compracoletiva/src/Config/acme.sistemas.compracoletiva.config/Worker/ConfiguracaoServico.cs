using acme.sistemas.compracoletiva.service.Works.Util;
using Microsoft.Extensions.DependencyInjection;

namespace acme.sistemas.compracoletiva.config.Worker
{
    public static class ConfiguracaoServico
    {
        public static void ConfigurarServico(this IServiceCollection services)
        {
            services.AddHostedService<EmailWorkerServico>();

        }
    }
}
