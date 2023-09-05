using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Services.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Services.UtilityDb
{
    public partial class UtilityDbService
    {
        public async Task<ServiceResult<PagedResponse<OrganizationalUnit>>> GetOrganizationalUnits(OrganizationalUnitCriteria criteria, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetOrganizationalUnitsQuery(criteria), cancellationToken);
        }

        public async Task<ServiceResult<bool>> DeleteOrganizationalUnit(int entityId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteOrganizationalUnitCommand(entityId), cancellationToken);
        }

        public async Task<ServiceResult<OrganizationalUnit>> AddOrganizationalUnit(OrganizationalUnit entity, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AddOrganizationalUnitCommand(entity), cancellationToken);
        }

        public async Task<ServiceResult<bool>> UpdateOrganizationalUnit(OrganizationalUnit entity, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateOrganizationalUnitCommand(entity), cancellationToken);
        }

        public async Task<ServiceResult<List<OrganizationalUnitAdmin>>> GetOrganizationalUnitAdmins(OrganizationalUnitAdminCriteria criteria, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetOrganizationalUnitAdminsQuery(criteria), cancellationToken);
        }
    }

}

