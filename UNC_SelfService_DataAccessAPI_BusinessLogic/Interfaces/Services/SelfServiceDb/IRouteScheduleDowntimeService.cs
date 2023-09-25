using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb;

public interface IRouteScheduleDowntimeService
{
    Task<ServiceResult<RouteScheduleDowntime>> AddRouteScheduleDowntime(RouteScheduleDowntime entity, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> DeleteRouteScheduleDowntime(int entityId, CancellationToken cancellationToken);
    Task<ServiceResult<List<RouteScheduleDowntime>>> GetRouteScheduleDowntimes(RouteScheduleDowntimeCriteria criteria, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> UpdateRouteScheduleDowntime(RouteScheduleDowntime entity, CancellationToken cancellationToken);
}
