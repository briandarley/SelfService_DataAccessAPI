using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;
public class AddRouteItemCommand : IRequest<ServiceResult<RouteItem>>
{
    internal RouteItem Entity { get; }
    public AddRouteItemCommand(RouteItem entity)
    {
        Entity = entity;
    }
}