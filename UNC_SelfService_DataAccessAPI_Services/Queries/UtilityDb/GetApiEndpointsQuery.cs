using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class GetApiEndpointsQuery : IRequest<ServiceResult<List<ApiEndpoint>>>
{


    public GetApiEndpointsQuery(UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb.ApiEndpointCriteria criteria)
    {
        Criteria = criteria;
    }

    public ApiEndpointCriteria Criteria { get; }
}