using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

public class GetRouteScheduleDowntimesQuery : IRequest<ServiceResult<List<RouteScheduleDowntime>>>
{
    public RouteScheduleDowntimeCriteria Criteria { get; }

    public GetRouteScheduleDowntimesQuery(RouteScheduleDowntimeCriteria criteria)
    {
        Criteria = criteria;
    }
}