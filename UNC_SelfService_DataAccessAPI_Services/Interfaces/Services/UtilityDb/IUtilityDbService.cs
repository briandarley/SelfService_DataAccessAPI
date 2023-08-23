using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.UtilityDb
{
    public interface IUtilityDbService
    {
        Task<List<AppSetting>> GetAppSettings(AppSettingsCriteria criteria, CancellationToken cancellationToken);
    }
}
