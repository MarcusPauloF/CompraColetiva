using acme.sistemas.compracoletiva.core.Base;
using acme.sistemas.compracoletiva.di.Installers;
using acme.sistemas.compracoletiva.infra.Config;
using acme.sistemas.compracoletiva.repository;
using acme.sistemas.compracoletiva.service.Interfaces.Worker.Util;
using acme.sistemas.compracoletiva.service.Works.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace acme.sistemas.compracoletiva.di
{
    public static class RegisterAll
    {
        public static IServiceCollection InstallDependencies(this IServiceCollection service)
        {
            service.AddScoped<Context>();
            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            service.AddSingleton<IEmailWorkerServico, EmailWorkerServico>();
            
            service.InstallDomainServices();
            service.InstallRepositories();

            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return service;
        }
    }
}
