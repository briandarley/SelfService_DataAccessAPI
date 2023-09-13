using Microsoft.AspNetCore.Mvc;
using UNC.API.Base;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Controllers.SelfServiceDb;



[Route("v1/self-service-db/menu-items")]
[ApiController]
[ApiExplorerSettings(GroupName = "selfServiceDb")]
public class MenuItemsController : BaseController
{
    private readonly ISelfServiceDbService _service;

    public MenuItemsController(ILogger<MenuItemsController> logger, ISelfServiceDbService service) : base(logger)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<IActionResult> GetAppSettings([FromQuery] MenuItemCriteria criteria, CancellationToken cancellationToken)
    {
        var request = await _service.GetMenuItems(criteria, cancellationToken);

        if (request.Success)
        {
            return Ok(request.Data);
        }

        return BadRequest(new { errors = request.Errors });

    }
    [HttpPost]
    public async Task<IActionResult> AddAppSetting(MenuItem entity, CancellationToken cancellationToken)
    {
        var request = await _service.AddMenuItem(entity, cancellationToken);

        if (request.Success)
        {
            return Ok(request.Data);
        }

        return BadRequest(new { errors = request.Errors });

    }
    [HttpPut, Route("{entityId}")]
    public async Task<IActionResult> UpdateMenuItem(int entityId, [FromBody] MenuItem entity, CancellationToken cancellationToken)
    {
        entity.Id = entityId;
        var request = await _service.UpdateMenuItem(entity, cancellationToken);


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
    public async Task<IActionResult> DeleteMenuItem(int entityId, CancellationToken cancellationToken)
    {
        var request = await _service.DeleteMenuItem(entityId, cancellationToken);

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