using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class AddOrganizationalUnitCommand : IRequest<ServiceResult<OrganizationalUnit>>
{
    internal OrganizationalUnit Entity;

    public AddOrganizationalUnitCommand(OrganizationalUnit entity)
    {
        Entity = entity;
    }
}