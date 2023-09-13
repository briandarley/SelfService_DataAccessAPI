using Microsoft.AspNetCore.Mvc;
using UNC.API.Base;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Controllers.UtilityDb;

[Route("v1/utilities-db/process-histories")]
[ApiController]
[ApiExplorerSettings(GroupName = "utilitiesDb")]
public class ProcessHistoriesControllerController : BaseController
{
    private readonly IProcessHistory _service;

    public ProcessHistoriesControllerController(ILogger<ProcessHistoriesControllerController> logger, IProcessHistory service) : base(logger)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<IActionResult> GetProcessHistories([FromQuery] ProcessHistoryCriteria criteria, CancellationToken cancellationToken)
    {
        var request = await _service.GetProcessHistories(criteria, cancellationToken);

        if (request.Success)
        {
            return Ok(request.Data);
        }

        return BadRequest(new { errors = request.Errors });

    }
    [HttpPost]
    public async Task<IActionResult> AddProcessHistory(ProcessHistory entity, CancellationToken cancellationToken)
    {
        var request = await _service.AddProcessHistory(entity, cancellationToken);

        if (request.Success)
        {
            return Ok(request.Data);
        }

        return BadRequest(new { errors = request.Errors });

    }
    [HttpPut, Route("{entityId}")]
    public async Task<IActionResult> UpdateProcessHistory(int entityId, [FromBody] ProcessHistory entity, CancellationToken cancellationToken)
    {
        entity.Id = entityId;
        var request = await _service.UpdateProcessHistory(entity, cancellationToken);


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
    public async Task<IActionResult> DeleteProcessHistory(int entityId, CancellationToken cancellationToken)
    {
        var request = await _service.DeleteProcessHistory(entityId, cancellationToken);

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

