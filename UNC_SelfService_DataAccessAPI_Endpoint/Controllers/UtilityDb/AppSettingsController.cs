using Microsoft.AspNetCore.Mvc;
using UNC.API.Base;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Controllers.UtilityDb
{
    [Route("v1/utilities-db/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "utilitiesDb")]
    public class AppSettingsController : BaseController
    {
        private readonly IUtilityDbService _service;

        public AppSettingsController(ILogger<AppSettingsController> logger, IUtilityDbService service) : base(logger)
        {
            _service = service;
        }

        [HttpGet, Route("app-settings")]
        public async Task<List<AppSetting>> GetAppSettings([FromQuery] AppSettingsCriteria criteria, CancellationToken cancellationToken)
        {
            return await _service.GetAppSettings(criteria, cancellationToken);
        }
    }
}
