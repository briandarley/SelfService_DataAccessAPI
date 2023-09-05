using MediatR;
using UNC.Services.Responses;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;
public class DeleteProcessCommand : IRequest<ServiceResult<bool>>
{
    internal int EntityId { get; }
    public DeleteProcessCommand(int entityId)
    {
        EntityId = entityId;
    }
}