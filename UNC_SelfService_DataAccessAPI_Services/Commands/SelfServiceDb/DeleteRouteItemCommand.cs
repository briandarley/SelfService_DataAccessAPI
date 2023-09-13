using MediatR;
using UNC.Services.Responses;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;
public class DeleteRouteItemCommand : IRequest<ServiceResult<bool>>
{
    internal int EntityId { get; }
    public DeleteRouteItemCommand(int entityId)
    {
        EntityId = entityId;
    }
}