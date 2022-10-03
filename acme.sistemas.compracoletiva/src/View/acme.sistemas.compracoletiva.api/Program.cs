using NLog.Web;
using acme.sistemas.compracoletiva.api;
using Microsoft.AspNetCore.Builder;

///Applicação

var builder = WebApplication.CreateBuilder(args);

var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
logger.Debug("Inicio");


if (builder.Environment.IsEnvironment("Testing"))
{
    var startup = new StartupApiTeste(builder.Configuration);
    startup.ConfigureServices(builder.Services);

    builder.Logging.AddJsonConsole();
    var app = builder.Build();

    startup.Configure(app, app.Environment, Startup.loggerFactory);

    app.Run();
}
else
{
    var startup = new Startup(builder.Configuration);
    startup.ConfigureServices(builder.Services);

    builder.Logging.AddJsonConsole();
    var app = builder.Build();

    startup.Configure(app, app.Environment, Startup.loggerFactory);

    app.Run();
}
logger.Debug("Fim");
public partial class Program { }
