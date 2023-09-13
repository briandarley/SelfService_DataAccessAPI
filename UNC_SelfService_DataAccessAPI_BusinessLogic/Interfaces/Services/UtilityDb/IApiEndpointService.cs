using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb
{
    public interface IApiEndpointService
    {
        Task<ServiceResult<List<ApiEndpoint>>> GetApiEndpoints(ApiEndpointCriteria criteria, CancellationToken cancellationToken);
        Task<ServiceResult<ApiEndpoint>> AddApiEndpoint(ApiEndpoint entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> UpdateApiEndpoint(ApiEndpoint entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> DeleteApiEndpoint(int entityId, CancellationToken cancellationToken);
    }
}
