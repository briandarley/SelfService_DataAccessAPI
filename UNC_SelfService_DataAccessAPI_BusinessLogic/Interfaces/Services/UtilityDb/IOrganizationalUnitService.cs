using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb
{
    public interface IOrganizationalUnitService
    {
        Task<ServiceResult<OrganizationalUnit>> AddOrganizationalUnit(OrganizationalUnit entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> DeleteOrganizationalUnit(int entityId, CancellationToken cancellationToken);
        Task<ServiceResult<PagedResponse<OrganizationalUnit>>> GetOrganizationalUnits(OrganizationalUnitCriteria criteria, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> UpdateOrganizationalUnit(OrganizationalUnit entity, CancellationToken cancellationToken);
        Task<ServiceResult<List<OrganizationalUnitAdmin>>> GetOrganizationalUnitAdmins(OrganizationalUnitAdminCriteria criteria, CancellationToken cancellationToken);
    }
}
