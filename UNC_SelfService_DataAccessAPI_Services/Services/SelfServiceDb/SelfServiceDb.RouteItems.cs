using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Services.Services.SelfServiceDb;

public partial class SelfServiceDbService
{

    public async Task<ServiceResult<List<RouteItem>>> GetRouteItems(RouteItemCriteria criteria, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetRouteItemsQuery(criteria), cancellationToken);
    }

    public async Task<ServiceResult<bool>> DeleteRouteItem(int entityId, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new DeleteRouteItemCommand(entityId), cancellationToken);
    }

    public async Task<ServiceResult<RouteItem>> AddRouteItem(RouteItem entity, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new AddRouteItemCommand(entity), cancellationToken);
    }

    public async Task<ServiceResult<bool>> UpdateRouteItem(RouteItem entity, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new UpdateRouteItemCommand(entity), cancellationToken);
    }
}

