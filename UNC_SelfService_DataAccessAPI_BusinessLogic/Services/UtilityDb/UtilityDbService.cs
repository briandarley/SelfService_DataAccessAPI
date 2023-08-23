using Microsoft.Extensions.Logging;
using UNC.Services;
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

        public Task<List<AppSetting>> GetAppSettings(AppSettingsCriteria criteria, CancellationToken cancellationToken)
        {
            return _service.GetAppSettings(criteria, cancellationToken);
        }
    }
}
