using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Services.Queries.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Services.UtilityDb
{
    public partial class UtilityDbService
    {

        public async Task<List<AppSetting>> GetAppSettings(AppSettingsCriteria criteria, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAppSettingsQuery(criteria), cancellationToken);
        }
    }
}
