using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.UtilityDb
{
    public interface IUtilityDbService
    {
        Task<ServiceResult<List<AppSetting>>> GetAppSettings(AppSettingsCriteria criteria, CancellationToken cancellationToken);
        Task<ServiceResult<AppSetting>> AddAppSetting(AppSetting entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> UpdateAppSetting(AppSetting entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> DeleteAppSetting(int entityId, CancellationToken cancellationToken);

        Task<ServiceResult<List<ApiEndpoint>>> GetApiEndpoints(ApiEndpointCriteria criteria, CancellationToken cancellationToken);
        Task<ServiceResult<ApiEndpoint>> AddApiEndpoint(ApiEndpoint entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> UpdateApiEndpoint(ApiEndpoint entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> DeleteApiEndpoint(int entityId, CancellationToken cancellationToken);
        Task<ServiceResult<List<OrganizationalUnitAdmin>>> GetOrganizationalUnitAdmins(OrganizationalUnitAdminCriteria criteria, CancellationToken cancellationToken);
        Task<ServiceResult<OrganizationalUnit>> AddOrganizationalUnit(OrganizationalUnit entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> DeleteOrganizationalUnit(int entityId, CancellationToken cancellationToken);
        Task<ServiceResult<PagedResponse<OrganizationalUnit>>> GetOrganizationalUnits(OrganizationalUnitCriteria criteria, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> UpdateOrganizationalUnit(OrganizationalUnit entity, CancellationToken cancellationToken);

    }
}
