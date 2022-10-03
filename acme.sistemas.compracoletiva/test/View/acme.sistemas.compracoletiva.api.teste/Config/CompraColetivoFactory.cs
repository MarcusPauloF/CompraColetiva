using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace acme.sistemas.compracoletiva.api.teste.Config
{
    public class CompraColetivoFactory : WebApplicationFactory<StartupApiTeste>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            //builder.UseEnvironment("Testing");
            //builder.ConfigureServices(services =>
            //{
            //    var descriptor = services.SingleOrDefault(
            //        d => d.ServiceType ==
            //            typeof(DbContextOptions<Context>));

            //    services.Remove(descriptor);

            //    services.AddDbContext<Context>(options =>
            //    {
            //        options.UseSqlServer("Server=localhost;Database=CompraColetiva; User Id=sa; Password=sa-1234", _ => _.MigrationsAssembly("acme.sistemas.compracoletiva.infra"));
            //        //options.UseInMemoryDatabase("InMemoryDbForTesting");
            //    });

            //    var sp = services.BuildServiceProvider();
            //    var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.Testing.json");
            //    var configuration = builder.Build();

            //    services.InstallDependencies();
            //    var tokenConfigurations = new ConfiguracaoToken();
            //    new ConfigureFromConfigurationOptions<ConfiguracaoToken>(configuration.GetSection("ConfiguracaoToken")).Configure(tokenConfigurations);
            //    services.ConfigurarToken(tokenConfigurations);

            //    services.AddDefaultIdentity<Usuario>(t =>
            //    {
            //        t.SignIn.RequireConfirmedAccount = true;
            //        t.SignIn.RequireConfirmedEmail = true;
            //    }).AddRoles<Permissao>()
            //    .AddEntityFrameworkStores<Context>();

            //    //using (var scope = sp.CreateScope())
            //    //{
            //    //    var scopedServices = scope.ServiceProvider;
            //    //    var db = scopedServices.GetRequiredService<Context>();
            //    //    var logger = scopedServices
            //    //        .GetRequiredService<ILogger<CompraColetivoFactory>>();

            //    //    db.Database.EnsureCreated();


            //    //}
            //});

        }
    }
}
