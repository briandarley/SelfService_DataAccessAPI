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
using UNC_SelfService_DataAccessAPI_Endpoint.GraphQl.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Infrastructure
{
    internal static class DIRegistrations
    {

        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration, ILogger logger)
        {

            services.AddGraphQLServer()
                .AddAuthorization()
                //.AddAuthorizationCore()
              .AddUtilityDbQueries();
             

            services.RegisterDefaultUserPrincipal();
            services.RegisterHttpClientDependencies();
            services.RegisterLazyHttpClientFactory();

            //setup swagger docs
            services.RegisterSwaggerDoc<Program>(configuration, GetSwaggerDocs());
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
            
            services.AddTransient<UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb.IApiEndpointService, UNC_SelfService_DataAccessAPI_BusinessLogic.Services.UtilityDb.UtilityDbService>();
            services.AddTransient<UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb.IAppSettingService, UNC_SelfService_DataAccessAPI_BusinessLogic.Services.UtilityDb.UtilityDbService>();
            services.AddTransient<UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb.IOrganizationalUnitService, UNC_SelfService_DataAccessAPI_BusinessLogic.Services.UtilityDb.UtilityDbService>();
            services.AddTransient<UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb.IProcessService, UNC_SelfService_DataAccessAPI_BusinessLogic.Services.UtilityDb.UtilityDbService>();
            services.AddTransient<UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb.IProcessHistory, UNC_SelfService_DataAccessAPI_BusinessLogic.Services.UtilityDb.UtilityDbService>();
            services.AddTransient<UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb.IUtilityDbService, UNC_SelfService_DataAccessAPI_BusinessLogic.Services.UtilityDb.UtilityDbService>();
            
            
            services.AddTransient<UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb.IMenuItemService, UNC_SelfService_DataAccessAPI_BusinessLogic.Services.SelfServiceDb.SelfServiceDbService>();
                services.AddTransient<UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb.IRouteItemService, UNC_SelfService_DataAccessAPI_BusinessLogic.Services.SelfServiceDb.SelfServiceDbService>();
            services.AddTransient<UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb.ISelfServiceDbService, UNC_SelfService_DataAccessAPI_BusinessLogic.Services.SelfServiceDb.SelfServiceDbService>();
            services.AddTransient<UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb.IRouteScheduleDowntimeService, UNC_SelfService_DataAccessAPI_BusinessLogic.Services.SelfServiceDb.RouteScheduleDowntimeService>();
        }

        private static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.UtilityDb.IUtilityDbService, UNC_SelfService_DataAccessAPI_Services.Services.UtilityDb.UtilityDbService>();
            services.AddTransient<UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.SelfServiceDb.ISelfServiceDbService, UNC_SelfService_DataAccessAPI_Services.Services.SelfServiceDb.SelfServiceDbService>();
            services.AddTransient<UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.SelfServiceDb.IRouteScheduleDowntimeService, UNC_SelfService_DataAccessAPI_Services.Services.SelfServiceDb.SelfServiceDbService>();
            
        }

        private static void RegisterDatabaseUnitOfWork(this IServiceCollection services)
        {
            //services.AddTransient<UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb.IUtilityDbService, UNC_SelfService_DataAccessAPI_BusinessLogic.Services.UtilityDb.UtilityDbService>();
            //services.AddTransient<UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb.ISelfServiceDbService, UNC_SelfService_DataAccessAPI_BusinessLogic.Services.SelfServiceDb.SelfServiceDbService>();

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

            services.AddDbContext<SelfServiceDbContext>(options => options.UseSqlServer(configuration["SelfServiceDBConnection"], opts => opts.EnableRetryOnFailure()));

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
                Name = "selfServiceDb",
                Title = "SelfServiceDb Controller",
                Version = "v1",
                Description = "API Endpoints for RWD of SelfServiceDb"
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
