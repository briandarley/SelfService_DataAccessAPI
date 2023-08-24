using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb
{
    public interface IUtilityDbService
    {
        Task<ServiceResult<List<AppSetting>>> GetAppSettings(AppSettingsCriteria criteria, CancellationToken cancellationToken);
        Task<ServiceResult<AppSetting>> AddAppSetting(AppSetting entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> UpdateAppSetting(AppSetting entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> DeleteAppSetting(int entityId, CancellationToken cancellationToken);
    }
}
