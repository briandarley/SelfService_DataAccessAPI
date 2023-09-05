using MediatR;
using UNC.Services.Responses;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;
public class DeleteProcessHistoryCommand : IRequest<ServiceResult<bool>>
{
    internal int EntityId { get; }
    public DeleteProcessHistoryCommand(int entityId)
    {
        EntityId = entityId;
    }
}