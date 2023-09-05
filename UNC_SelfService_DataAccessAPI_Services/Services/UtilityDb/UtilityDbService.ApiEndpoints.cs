using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Services.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Services.UtilityDb
{
    public partial class UtilityDbService
    {
        public async Task<ServiceResult<List<ApiEndpoint>>> GetApiEndpoints(ApiEndpointCriteria criteria, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetApiEndpointsQuery(criteria), cancellationToken);
        }

        public async Task<ServiceResult<bool>> DeleteApiEndpoint(int entityId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteApiEndpointCommand(entityId), cancellationToken);
        }

        public async Task<ServiceResult<ApiEndpoint>> AddApiEndpoint(ApiEndpoint entity, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AddApiEndpointCommand(entity), cancellationToken);
        }

        public async Task<ServiceResult<bool>> UpdateApiEndpoint(ApiEndpoint entity, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateApiEndpointCommand(entity), cancellationToken);
        }
    }
}
