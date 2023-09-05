using MediatR;
using UNC.Services.Responses;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class DeleteOrganizationalUnitAdminCommand : IRequest<ServiceResult<bool>>
{
    

    public DeleteOrganizationalUnitAdminCommand(int entityId)
    {
    
        EntityId = entityId;
    }

    public int EntityId { get; }
}
