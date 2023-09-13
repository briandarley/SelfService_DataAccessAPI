using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

public class GetRouteItemsQuery : IRequest<ServiceResult<List<RouteItem>>>
{
    public RouteItemCriteria Criteria { get; }

    public GetRouteItemsQuery(RouteItemCriteria criteria)
    {
        Criteria = criteria;
    }
}