using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class UpdateOrganizationalUnitAdminCommand : IRequest<ServiceResult<bool>>
{
    internal OrganizationalUnitAdmin Entity;

    public UpdateOrganizationalUnitAdminCommand(OrganizationalUnitAdmin entity)
    {
        Entity = entity;
    }
}
