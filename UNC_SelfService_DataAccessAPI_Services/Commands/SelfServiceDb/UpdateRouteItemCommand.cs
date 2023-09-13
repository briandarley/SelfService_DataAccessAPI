using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;
public class UpdateRouteItemCommand : IRequest<ServiceResult<bool>>
{
    internal RouteItem Entity { get; }
    public UpdateRouteItemCommand(RouteItem entity)
    {
        Entity = entity;
    }
}