using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_BusinessLogic.Services.UtilityDb
{
    public class UtilityDbService : ServiceBase<UtilityDbService>, IUtilityDbService
    {
        private readonly UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.UtilityDb.IUtilityDbService _service;

        public UtilityDbService(ILogger<UtilityDbService> logger, UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.UtilityDb.IUtilityDbService service) : base(logger)
        {
            _service = service;
        }

        public Task<ServiceResult<List<AppSetting>>> GetAppSettings(AppSettingsCriteria criteria, CancellationToken cancellationToken)
        {
            return _service.GetAppSettings(criteria, cancellationToken);
        }
        public Task<ServiceResult<AppSetting>> AddAppSetting(AppSetting entity, CancellationToken cancellationToken)
        {
            return _service.AddAppSetting(entity, cancellationToken);
        }
        public async Task<ServiceResult<bool>> UpdateAppSetting(AppSetting entity, CancellationToken cancellationToken)
        {

            var request = await _service.GetAppSettings(new AppSettingsCriteria { Id = entity.Id }, cancellationToken);
            if (request.Success)
            {
                var appSetting = request.Data.FirstOrDefault();
                if (appSetting != null)
                {
                    appSetting.Value = entity.Value;
                    return await _service.UpdateAppSetting(appSetting, cancellationToken);
                }
                else
                {
                    return new ServiceResult<bool>(false, "ResourceNotFound");
                }
            }
            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }
        public async Task<ServiceResult<bool>> DeleteAppSetting(int entityId, CancellationToken cancellationToken)
        {
            
            var request = await _service.GetAppSettings(new AppSettingsCriteria { Id = entityId }, cancellationToken);
            if (request.Success)
            {
                var appSetting = request.Data.FirstOrDefault();
                if (appSetting != null)
                {
                    return await _service.DeleteAppSetting(entityId, cancellationToken);
                }
                else
                {
                    return new ServiceResult<bool>(false, "ResourceNotFound");
                }
            }
            
            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }

    }
}
