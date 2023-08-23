using System.Diagnostics;
using UNC.API.Base.Infrastructure;
using UNC.LogHandler.Extensions;
using UNC.Services.Infrastructure;
using UNC.HttpClient.Extensions;
using UNC.API.Base.Models;
using UNC_SelfService_DataAccessAPI_Services;
using UNC.HttpClient.Interfaces;
using UNC.Services.Utilities;
using UNC_SelfService_DataAccessAPI_Repository;
using Microsoft.EntityFrameworkCore;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Infrastructure
{
    internal static class DIRegistrations
    {

        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            ILogger logger = null;
            if (Debugger.IsAttached)
            {
                // Create LoggerFactory
                var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
                logger = loggerFactory.CreateLogger<Program>();
            }

            services.RegisterDefaultUserPrincipal();
            services.RegisterHttpClientDependencies();
            services.RegisterLazyHttpClientFactory();

            //setup swagger docs
            services.RegisterSwaggerDoc(configuration, GetSwaggerDocs());
            //register AddAuthentication, Authorization, overloads relies on identity server parameters in {configuration}
            //Setting SkipAuth to false will bypass authentication and authorization
            //services.RegisterBearerFromConfiguration(configuration, GetCustomListOfPolicies());
            services.RegisterBearerFromEnvironmentVariable(configuration,GetCustomListOfPolicies());

            //register custom controller registration, overloads relies on identity server parameters in {configuration}
            services.AddCustomControllerRegistration(configuration);

            //register UNC Log Client "UncLogClient"
            services.RegisterUncLogClient();

            services.AddEndpointsApiExplorer();
            services.AddHttpClient();

            services.RegisterApplicationServices();
            services.RegisterInfrastructureServices();

            services.RegisterApiVersioning();


            var allowedCorsOrigins = configuration.GetSection("AllowedCorsOrigins").Get<string[]>();
            services.RegisterDefaultCors(allowedCorsOrigins);


            services.RegisterDefaultMvcSerialization();


            services.RegisterDatabaseUnitOfWork();
            services.RegisterDatabaseContexts(configuration, logger);
            services.AddSetupDependencies();

        }

        private static void RegisterApplicationServices(this IServiceCollection services)
        {
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.UtilityDb.IUtilityDbService, UNC.DAL.Data.Application.Services.UtilityDb.UtilityDbService>();
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.SplunkDb.ISplunkDbService, UNC.DAL.Data.Application.Services.SplunkDb.SplunkDbService>();
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.MidPointDb.IMidPointDbService, UNC.DAL.Data.Application.Services.MidPointDb.MidPointDbServices>();
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.WinToolsDb.IWinToolsDbService, UNC.DAL.Data.Application.Services.WinToolsDb.WinToolsDbService>();
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.O365Db.IO365DbServices, UNC.DAL.Data.Application.Services.O365Db.O365DbServices>();

            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.LiveDuDb.IAliasDomainsService, UNC.DAL.Data.Application.Services.LiveDuDb.LiveDuDbService>();
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.LiveDuDb.IAcademicGroupCodeService, UNC.DAL.Data.Application.Services.LiveDuDb.LiveDuDbService>();
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.LiveDuDb.IEmailAliasDomainService, UNC.DAL.Data.Application.Services.LiveDuDb.LiveDuDbService>();

            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.LiveDuDb.ITenantInfoService, UNC.DAL.Data.Application.Services.LiveDuDb.LiveDuDbService>();
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.LiveDuDb.ILiveDuDbService, UNC.DAL.Data.Application.Services.LiveDuDb.LiveDuDbService>();
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.LiveDuDb.IConfigurationService, UNC.DAL.Data.Application.Services.LiveDuDb.LiveDuDbService>();
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.LiveDuDb.IActiveDirectoryChangeHistoryService, UNC.DAL.Data.Application.Services.LiveDuDb.LiveDuDbService>();
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.IdentityDb.IIdentityDbService, UNC.DAL.Data.Application.Services.IdentityDb.IdentityDbService>();
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.MimsDb.IMimsDbService, UNC.DAL.Data.Application.Services.MimsDb.MimsDbService>();
            //services.AddTransient<UNC.DAL.Data.Application.Interfaces.LyrisDb.ILyrisDbService, UNC.DAL.Data.Application.Services.LyrisDb.LyrisDbService>();

        }

        private static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            //services.AddTransient<UNC.DAL.Data.Infrastructure.Interfaces.Services.UtilityDb.IUtilityDbService, UNC.DAL.Data.Infrastructure.Services.UtilityDb.UtilityDbService>();
            //services.AddTransient<UNC.DAL.Data.Infrastructure.Interfaces.Services.SplunkDb.ISplunkDbService, UNC.DAL.Data.Infrastructure.Services.SplunkDb.SplunkDbService>();
            //services.AddTransient<UNC.DAL.Data.Infrastructure.Interfaces.Services.MidPointDb.IMidPointDbServices, UNC.DAL.Data.Infrastructure.Services.MidPointDb.MidPointDbServices>();
            //services.AddTransient<UNC.DAL.Data.Infrastructure.Interfaces.Services.WinToolsDb.IWinToolsDbService, UNC.DAL.Data.Infrastructure.Services.WinToolsDb.WinToolsDbService>();
            //services.AddTransient<UNC.DAL.Data.Infrastructure.Interfaces.Services.O365Db.IO365DbServices, UNC.DAL.Data.Infrastructure.Services.O365Db.O365DbServices>();
            //services.AddTransient<UNC.DAL.Data.Infrastructure.Interfaces.Services.LiveDuDb.ILiveDuDbService, UNC.DAL.Data.Infrastructure.Services.LiveDuDb.LiveDuDbService>();
            //services.AddTransient<UNC.DAL.Data.Infrastructure.Interfaces.Services.IdentityDb.IIdentityService, UNC.DAL.Data.Infrastructure.Services.IdentityDb.IdentityService>();
            //services.AddTransient<UNC.DAL.Data.Infrastructure.Interfaces.Services.MimsDb.IMimsDbService, UNC.DAL.Data.Infrastructure.Services.MimsDb.MimsDbService>();
            //services.AddTransient<UNC.DAL.Data.Infrastructure.Interfaces.Services.LyrisDb.ILyrisDbService, UNC.DAL.Data.Infrastructure.Services.LyrisDb.LyrisDbService>();
        }

        private static void RegisterDatabaseUnitOfWork(this IServiceCollection services)
        {
            //services.AddTransient<IUtilityDbContext, UNC.DAL.Data.Infrastructure.DatabaseContexts.UtilityDbContext>();
            //services.AddTransient<IMidPointDbContext, UNC.DAL.Data.Infrastructure.DatabaseContexts.MidPointDbContext>();
            //services.AddTransient<ISplunkDbContext, UNC.DAL.Data.Infrastructure.DatabaseContexts.SplunkDbContext>();
            //services.AddTransient<IWinToolsDbContext, UNC.DAL.Data.Infrastructure.DatabaseContexts.WinToolsDbContext>();
            //services.AddTransient<IO365DbContext, UNC.DAL.Data.Infrastructure.DatabaseContexts.O365DbContext>();
            //services.AddTransient<ILiveDuDbContext, UNC.DAL.Data.Infrastructure.DatabaseContexts.LiveDuDbContext>();
            //services.AddTransient<ILyrisDbContext, UNC.DAL.Data.Infrastructure.DatabaseContexts.LyrisDbContext>();
            //services.AddTransient<IIdentityDbContext, UNC.DAL.Data.Infrastructure.DatabaseContexts.IdentityDbContext>();
            //services.AddTransient<IMimsDbContext, UNC.DAL.Data.Infrastructure.DatabaseContexts.MimsDbContext>();

        }

        private static void RegisterDatabaseContexts(this IServiceCollection services, IConfiguration configuration, ILogger logger)
        {
           

            logger?.LogInformation("Attempting to register DBContext");

            logger?.LogInformation($"UTILITYDB: {configuration["UtilityDBConnection"]}");


            //UtilityDb

            services.AddDbContext<UtilityDbContext>(options => options.UseSqlServer(configuration["UtilityDBConnection"], opts => opts.EnableRetryOnFailure()));

            ////MidPointDb

            //services.AddDbContext<UNC.DAL.Data.Infrastructure.DatabaseContexts.MidPointDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:MidPointDB"], opts => opts.EnableRetryOnFailure()));

            //services.AddDbContext<UNC.DAL.Data.Infrastructure.DatabaseContexts.SplunkDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:SplunkDb"], opts => opts.EnableRetryOnFailure()));


            //services.AddDbContext<UNC.DAL.Data.Infrastructure.DatabaseContexts.WinToolsDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:WinToolsDB"], opts => opts.EnableRetryOnFailure()));




            //services.AddDbContext<UNC.DAL.Data.Infrastructure.DatabaseContexts.O365DbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:Office365DB"], opts => opts.EnableRetryOnFailure()));
            //services.AddDbContext<UNC.DAL.Data.Infrastructure.DatabaseContexts.LiveDuDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:LiveDuDB"], opts => opts.EnableRetryOnFailure()));

            //services.AddDbContext<UNC.DAL.Data.Infrastructure.DatabaseContexts.LyrisDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:LyrisDb"], opts => opts.EnableRetryOnFailure()));


            //services.AddDbContext<UNC.DAL.Data.Infrastructure.DatabaseContexts.IdentityDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:IdentityDB"], opts => opts.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery).EnableRetryOnFailure()));



            //services.AddDbContext<UNC.DAL.Data.Infrastructure.DatabaseContexts.MimsDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:MIMSUnifiedGALDB"], opts => opts.EnableRetryOnFailure()));


        }


        private static void AddSetupDependencies(this IServiceCollection services)
        {
            //MapperService.RegisterMappings();
            //services.AddSingleton<ApplicationModeService>();

            services.AddHttpContextAccessor();
            //services.RegisterAutoMapper<AutoMapperService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IApiAssemblyMarker).Assembly));

            services.RegisterApiEndPoints();
            services.AddSingleton<IApiResources>(cfg =>
            {
                var configuration = cfg.GetRequiredService<IConfiguration>();
                var node = configuration.GetSection("Endpoints").GetChildren();
                var appResources = (IApiResources)new UNC.HttpClient.Models.ApiResources();
                foreach (var section in node)
                {
                    var resource = new UNC.HttpClient.Models.ApiResource { Address = section.Value, Name = section.Key };
                    appResources.Resources.Add(resource);
                }

                return appResources;

            });


            //services.AddSingleton<MapperService>(cfg =>
            //{
            //    return new MapperService();
            //});
            services.AddSingleton<KerberosHelper>();


        }

        private static List<SwaggerDocConfig> GetSwaggerDocs()
        {

            return new List<SwaggerDocConfig>
        {
            new SwaggerDocConfig
            {
                Name = "utilitiesDb",
                Title = "UtilitiesDb Controller",
                Version = "v1",
                Description = "API Endpoints for RWD of UtilitiesDb"
            },
            new SwaggerDocConfig
            {
                Name = "splunkDb",
                Title = "SplunkDb Controller",
                Version = "v1",
                Description = "API Endpoints for RW of SplunkDb"
            },
            new SwaggerDocConfig
            {
                Name = "midPointDb",
                Title = "MidPointDb Controller",
                Version = "v1",
                Description = "API Endpoints for RWD of MidPointDb"
            },
            new SwaggerDocConfig
            {
                Name = "winToolsDb",
                Title = "WinToolsDb Controller",
                Version = "v1",
                Description = "API Endpoints for RWD of WinToolsDb"
            },
            new SwaggerDocConfig
            {
                Name = "O365Db",
                Title = "O365Db Controller",
                Version = "v1",
                Description = "API Endpoints for RWD of Office365Db"
            },
            new SwaggerDocConfig
            {
                Name = "liveDuDb",
                Title = "LiveDuDb Controller",
                Version = "v1",
                Description = "API Endpoints for RWD of LiveDuDb"
            },
            new SwaggerDocConfig
            {
                Name = "identityDb",
                Title = "IdentityDb Controller",
                Version = "v1",
                Description = "API Endpoints for RWD of IdentityDb"
            },
            new SwaggerDocConfig
            {
                Name = "mimsDb",
                Title = "MimsDb Controller",
                Version = "v1",
                Description = "API Endpoints for RWD of MimsDb"
            },
            new SwaggerDocConfig
            {
                Name = "lryisDb",
                Title = "LyrisDb Controller",
                Version = "v1",
                Description = "API Endpoints for RWD of LyrisDb"
            },
            new SwaggerDocConfig
            {
                Name = "sqlbroker",
                Title = "SQL Broker Messages Controller",
                Version = "v1",
                Description = "API Endpoints for R of SQL Broker Messages"
            },
            new SwaggerDocConfig
            {
                Name = "tests",
                Title = "Test Controller",
                Version = "v1",
                Description = "Test endpoints"
            }

        };
        }
        private static List<UNC.Services.Models.CustomPolicy> GetCustomListOfPolicies()
        {
            return new List<UNC.Services.Models.CustomPolicy> {
                new UNC.Services.Models.CustomPolicy {
                    Name = "Read",
                    RequiredScopes = new List<string> { "DAL_DATA_ACCESS" }
                } ,
                new UNC.Services.Models.CustomPolicy {
                    Name = "Write",
                    RequiredScopes = new List<string> { "DAL_DATA_ACCESS" }
                } ,

        };
        }
    }
}
