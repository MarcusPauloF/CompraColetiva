using acme.sistemas.compracoletiva.api.Configurations.Filtler;
using acme.sistemas.compracoletiva.config.Security;
using acme.sistemas.compracoletiva.di;
using acme.sistemas.compracoletiva.domain.Entity.Security;
using acme.sistemas.compracoletiva.domain.Entity.Users;
using acme.sistemas.compracoletiva.infra.Config;
using acme.sistemas.compracoletiva.service.Works.Util;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using System.IO.Compression;
using System.Text.Json.Serialization;

namespace acme.sistemas.compracoletiva.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(_ => _.LowercaseUrls = true);

            services.AddResponseCompression();
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.SmallestSize;
            });
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.SmallestSize;
            });

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));


            services.AddDbContext<Context>(op => op.UseMySql(Configuration.GetConnectionString("CompraColetiva"), serverVersion)
            .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

            /*services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CompraColetiva"), _ => _.MigrationsAssembly("acme.sistemas.compracoletiva.infra"));
            });*/
            services.InstallDependencies();
            var tokenConfigurations = new ConfiguracaoToken();
            new ConfigureFromConfigurationOptions<ConfiguracaoToken>(
                Configuration.GetSection("ConfiguracaoToken"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);
            services.ConfigurarToken(tokenConfigurations);



            services.AddDefaultIdentity<Usuario>(t =>
            {
                t.SignIn.RequireConfirmedAccount = true;
                t.SignIn.RequireConfirmedEmail = true;
            }).AddRoles<Permissao>().
           AddEntityFrameworkStores<Context>();

            services.AddTransient<UnitOfWorkFilter>();
            services.AddHostedService<EmailWorkerServico>();

            services.AddControllers()
                /*.AddFluentValidation(_ => {
                    _.RegisterValidatorsFromAssemblyContaining<AnuncioWebmotorsValidador>();
                    _.DisableDataAnnotationsValidation = true;
                }).SetCompatibilityVersion(_ => {
                    _.RegisterValidatorsFromAssemblyContaining<AnuncioWebmotorsValidador>();
                    _.DisableDataAnnotationsValidation = true;
                })*/.AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CompraColetiva.Api", Version = "v1" });
                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Please enter JWT with Bearer into field"

                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

        }

        public void Configure(WebApplication app, IWebHostEnvironment env, ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompqraColetiva.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            logger.CreateLogger($"log_compracoletiva_${DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}");
            app.UseResponseCompression();

            app.MapControllers();

        }

        internal static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.ClearProviders();
            builder.SetMinimumLevel(LogLevel.Trace);

            builder.AddNLog();
            builder.AddJsonConsole();
            builder.AddConsole();
        });
    }
}
