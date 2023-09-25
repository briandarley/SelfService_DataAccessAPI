using Microsoft.AspNetCore.Mvc;
using UNC.API.Base;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Controllers.SelfServiceDb;
[Route("v1/self-service-db/route-schedule-downtime")]
[ApiController]
[ApiExplorerSettings(GroupName = "selfServiceDb")]
public class RouteScheduleDowntimeController : BaseController
{
    private readonly IRouteScheduleDowntimeService _service;

    public RouteScheduleDowntimeController(ILogger<RouteScheduleDowntimeController> logger, UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb.IRouteScheduleDowntimeService service) : base(logger)
    {
        _service = service;
    }

    


    [HttpGet]
    public async Task<IActionResult> GetRouteScheduleDowntimes([FromQuery] RouteScheduleDowntimeCriteria criteria, CancellationToken cancellationToken)
    {
        var request = await _service.GetRouteScheduleDowntimes(criteria, cancellationToken);

        if (request.Success)
        {
            return Ok(request.Data);
        }

        return BadRequest(new { errors = request.Errors });

    }
    [HttpPost]
    public async Task<IActionResult> AddRouteScheduleDowntime([FromBody] RouteScheduleDowntime entity, CancellationToken cancellationToken)
    {
        var request = await _service.AddRouteScheduleDowntime(entity, cancellationToken);

        if (request.Success)
        {
            return Ok(request.Data);
        }

        return BadRequest(new { errors = request.Errors });


    }
    [HttpPut, Route("{entityId}")]
    public async Task<IActionResult> UpdateRouteScheduleDowntime(int entityId, [FromBody]RouteScheduleDowntime entity, CancellationToken cancellationToken)
    {
        entity.Id = entityId;
        var request = await _service.UpdateRouteScheduleDowntime(entity, cancellationToken);


        if (request.Success)
        {
            return Ok(request.Data);
        }

        if (request.Errors.Contains("ResourceNotFound"))
        {
            return NotFound();
        }


        return BadRequest(new { errors = request.Errors });


    }
    [HttpDelete, Route("{entityId}")]
    public async Task<IActionResult> DeleteRouteScheduleDowntime(int entityId, CancellationToken cancellationToken)
    {
        var request = await _service.DeleteRouteScheduleDowntime(entityId, cancellationToken);

        if (request.Success)
        {
            return NoContent(); // Returns HTTP 204 No Content
        }

        if (request.Errors.Contains("ResourceNotFound"))
        {
            return NotFound();
        }

        return BadRequest(new { errors = request.Errors });

    }


}
