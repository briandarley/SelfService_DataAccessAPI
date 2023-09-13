using Microsoft.AspNetCore.Mvc;
using UNC.API.Base;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Controllers.UtilityDb;

[Route("v1/utilities-db/app-settings")]
[ApiController]
[ApiExplorerSettings(GroupName = "utilitiesDb")]
public class AppSettingsController : BaseController
{
    private readonly IAppSettingService _service;

    public AppSettingsController(ILogger<AppSettingsController> logger, IAppSettingService service) : base(logger)
    {
        _service = service;
    }

    [HttpGet, ]
    public async Task<IActionResult> GetAppSettings([FromQuery] AppSettingsCriteria criteria, CancellationToken cancellationToken)
    {
        var request = await _service.GetAppSettings(criteria, cancellationToken);

        if (request.Success)
        {
            return Ok(request.Data);
        }

        return BadRequest(new { errors = request.Errors });

    }
    [HttpPost, ]
    public async Task<IActionResult> AddAppSettings(AppSetting entity, CancellationToken cancellationToken)
    {
        var request = await _service.AddAppSetting(entity, cancellationToken);

        if (request.Success)
        {
            return Ok(request.Data);
        }

        return BadRequest(new { errors = request.Errors });

    }
    [HttpPut, Route("{entityId}")]
    public async Task<IActionResult> UpdateAppSettings(int entityId, [FromBody] AppSetting entity, CancellationToken cancellationToken)
    {
        entity.Id = entityId;
        var request = await _service.UpdateAppSetting(entity, cancellationToken);


        if (request.Success)
        {
            return Ok(request.Data);
        }

        if (request.Errors.Contains(UNC.Models.Constants.ResponseCodes.ResourceNotFound))
        {
            return NotFound();
        }

        return BadRequest(new { errors = request.Errors });

    }
    [HttpDelete, Route("{entityId}")]
    public async Task<IActionResult> DeleteAppSettings(int entityId, CancellationToken cancellationToken)
    {
        var request = await _service.DeleteAppSetting(entityId, cancellationToken);

        if (request.Success)
        {
            return NoContent(); // Returns HTTP 204 No Content
        }

        if (request.Errors.Contains(UNC.Models.Constants.ResponseCodes.ResourceNotFound))
        {
            return NotFound();
        }

        return BadRequest(new { errors = request.Errors });
    }


}
