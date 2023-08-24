using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Services.Commands.UtilityDb;
using UNC_SelfService_DataAccessAPI_Services.Queries.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Services.UtilityDb
{
    public partial class UtilityDbService
    {

        public async Task<ServiceResult<List<AppSetting>>> GetAppSettings(AppSettingsCriteria criteria, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAppSettingsQuery(criteria), cancellationToken);
        }
        public async Task<ServiceResult<AppSetting>> AddAppSetting(AppSetting entity, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AddAppSettingCommand(entity), cancellationToken);
        }
        public async Task<ServiceResult<bool>> UpdateAppSetting(AppSetting entity, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateAppSettingCommand(entity), cancellationToken);
        }
        public async Task<ServiceResult<bool>> DeleteAppSetting(int entityId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteAppSettingCommand(entityId), cancellationToken);
        }
    }
}
