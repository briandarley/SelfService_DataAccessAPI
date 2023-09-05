using MediatR;
using UNC.Services.Responses;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class DeleteApiEndpointCommand : IRequest<ServiceResult<bool>>
{
    public int EntityId { get; internal set; }

    public DeleteApiEndpointCommand(int entityId)
    {
        EntityId = entityId;
    }

    
}