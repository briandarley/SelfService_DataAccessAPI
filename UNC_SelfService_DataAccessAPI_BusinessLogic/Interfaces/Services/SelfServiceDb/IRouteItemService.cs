using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb;

public interface IRouteItemService
{
    Task<ServiceResult<RouteItem>> AddRouteItem(RouteItem entity, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> DeleteRouteItem(int entityId, CancellationToken cancellationToken);
    Task<ServiceResult<List<RouteItem>>> GetRouteItems(RouteItemCriteria criteria, CancellationToken cancellationToken);
    Task<ServiceResult<bool>> UpdateRouteItem(RouteItem entity, CancellationToken cancellationToken);
}
