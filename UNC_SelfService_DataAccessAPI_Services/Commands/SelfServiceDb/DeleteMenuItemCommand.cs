using MediatR;
using UNC.Services.Responses;

namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;
public class DeleteMenuItemCommand : IRequest<ServiceResult<bool>>
{
    internal int EntityId { get; }
    public DeleteMenuItemCommand(int entityId)
    {
        EntityId = entityId;
    }
}