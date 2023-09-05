using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class UpdateOrganizationalUnitCommand : IRequest<ServiceResult<bool>>
{
    internal OrganizationalUnit Entity;

    public UpdateOrganizationalUnitCommand(OrganizationalUnit entity)
    {
        Entity = entity;
    }
}
