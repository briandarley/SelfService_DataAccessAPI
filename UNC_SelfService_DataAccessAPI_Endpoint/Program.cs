
using System.Diagnostics;
using UNC.API.Base.Infrastructure;
using UNC.LogHandler.Extensions;
using UNC.Services.Infrastructure;
using UNC_SelfService_DataAccessAPI_Endpoint.Infrastructure;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());

var configuration = ConfigurationFileReaderService.GetConfiguration<Program>(builder);
builder.Configuration.AddConfiguration(configuration);


ILogger logger = null;

if(Debugger.IsAttached)
{
    //logger = UNC.LogHandler.Extensions.Extensions.GetLoggerForBuildCycle<Program>(configuration, LogLevel.Debug);
}

builder.Services.RegisterDependencies(configuration,logger);
builder.Host.RegisterSerilog(logger);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment() && !Debugger.IsAttached)
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

app.ConfigureAppMiddleware(RegisterSwaggerMappings);

app.Run();



static WebApplication RegisterSwaggerMappings(WebApplication app)
{
    var mappings = new List<UNC.API.Base.Models.SwaggerEndpointMappings>
                {
                    new UNC.API.Base.Models.SwaggerEndpointMappings
                    {
                        Name = "UtilitiesDb Controller",
                        Url = "utilitiesDb/swagger.json"
                    },
                    new UNC.API.Base.Models.SwaggerEndpointMappings
                    {
                        Name = "SplunkDb Controller",
                        Url = "splunkDb/swagger.json"
                    },
                    new UNC.API.Base.Models.SwaggerEndpointMappings
                    {
                        Name = "MidPointDb Controller",
                        Url = "midPointDb/swagger.json"
                    },
                    new UNC.API.Base.Models.SwaggerEndpointMappings
                    {
                        Name = "WinToolsDb Controller",
                        Url = "winToolsDb/swagger.json"
                    },
                    new UNC.API.Base.Models.SwaggerEndpointMappings
                    {
                        Name = "Office365Db Controller",
                        Url = "O365Db/swagger.json"
                    },
                    new UNC.API.Base.Models.SwaggerEndpointMappings
                    {
                        Name = "LiveDuDb Controller",
                        Url = "liveDuDb/swagger.json"
                    },
                    new UNC.API.Base.Models.SwaggerEndpointMappings
                    {
                        Name = "IdentityDb Controller",
                        Url = "identityDb/swagger.json"
                    },
                    new UNC.API.Base.Models.SwaggerEndpointMappings
                    {
                        Name = "MimsDb Controller",
                        Url = "mimsDb/swagger.json"
                    },
                    new UNC.API.Base.Models.SwaggerEndpointMappings
                    {
                        Name = "LyrisDb Controller",
                        Url = "lryisDb/swagger.json"
                    },
                    new UNC.API.Base.Models.SwaggerEndpointMappings
                    {
                        Name = "SQL Broker Messages Controller",
                        Url = "sqlbroker/swagger.json"
                    },
                    new UNC.API.Base.Models.SwaggerEndpointMappings
                    {
                        Name = "Test Controller",
                        Url = "tests/swagger.json"
                    }

            };
    app.ConfigureSwaggerMiddleware(mappings);
    return app;

}