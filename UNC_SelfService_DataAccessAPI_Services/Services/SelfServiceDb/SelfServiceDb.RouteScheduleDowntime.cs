using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Services.Services.SelfServiceDb;

public partial class SelfServiceDbService
{
    public async Task<ServiceResult<List<RouteScheduleDowntime>>> GetRouteScheduleDowntimes(RouteScheduleDowntimeCriteria criteria, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetRouteScheduleDowntimesQuery(criteria), cancellationToken);
    }

    public async Task<ServiceResult<bool>> DeleteRouteScheduleDowntime(int entityId, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new DeleteRouteScheduleDowntimeCommand(entityId), cancellationToken);
    }

    public async Task<ServiceResult<RouteScheduleDowntime>> AddRouteScheduleDowntime(RouteScheduleDowntime entity, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new AddRouteScheduleDowntimeCommand(entity), cancellationToken);
    }

    public async Task<ServiceResult<bool>> UpdateRouteScheduleDowntime(RouteScheduleDowntime entity, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new UpdateRouteScheduleDowntimeCommand(entity), cancellationToken);
    }
}


