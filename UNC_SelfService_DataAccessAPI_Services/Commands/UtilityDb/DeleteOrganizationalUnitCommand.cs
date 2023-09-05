using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class DeleteOrganizationalUnitCommand : IRequest<ServiceResult<bool>>
{
    

    public DeleteOrganizationalUnitCommand(int entityId)
    {
        
        EntityId = entityId;
    }

    public int EntityId { get; }
}
