using HotChocolate.Execution.Configuration;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Endpoint.GraphQLTypes.UNC_SelfService_DataAccessAPI_Endpoint.GraphQL.Types;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb;
using UNC_SelfService_DataAccessAPI_Endpoint.GraphQl.UtilityDb.GraphQLTypes;
using HotChocolate.Authorization;

namespace UNC_SelfService_DataAccessAPI_Endpoint.GraphQl.UtilityDb
{
    public static class GraphQLExtensions
    {

        public static IRequestExecutorBuilder AddUtilityDbQueries(this IRequestExecutorBuilder builder)
        {
            return builder
                .AddQueryType<UtilityDbQuery>()
                .AddFeatureTypes();
        }


        public static IRequestExecutorBuilder AddFeatureTypes(this IRequestExecutorBuilder builder)
        {
            return builder
                .AddType<ApiEndpointType>()
                .AddType<AppSettingType>()
                .AddType<AppSettingsCriteria>()
                .AddType<ApiEndpointCriteria>()
                .AddType<AppSettingsCriteriaType>()
                .AddType<ApiEndpointCriteriaType>()
                .AddType(new ServiceResultType<ApiEndpoint, ApiEndpointType>())
                .AddType(new ServiceResultType<AppSetting, AppSettingType>());


        }

        public class UtilityDbQuery
        {

            [Authorize]
            public Task<ServiceResult<List<ApiEndpoint>>> GetApiEndpoints(ApiEndpointCriteria criteria, CancellationToken cancellationToken, [Service] IUtilityDbService utilityDbService) => utilityDbService.GetApiEndpoints(criteria,cancellationToken);
            [Authorize]
            public Task<ServiceResult<List<AppSetting>>> GetAppSettings(AppSettingsCriteria criteria, CancellationToken cancellationToken, [Service] IUtilityDbService utilityDbService) => utilityDbService.GetAppSettings(criteria, cancellationToken);

        }

    }
}
