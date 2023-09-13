using Microsoft.AspNetCore.Mvc;
using UNC.API.Base;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Controllers.SelfServiceDb
{
    [Route("v1/self-service-db/route-items")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "selfServiceDb")]
    public class RouteItemsController : BaseController
    {
        private readonly ISelfServiceDbService _service;

        public RouteItemsController(ILogger<RouteItemsController> logger, ISelfServiceDbService service) : base(logger)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAppSettings([FromQuery] RouteItemCriteria criteria, CancellationToken cancellationToken)
        {
            var request = await _service.GetRouteItems(criteria, cancellationToken);

            if (request.Success)
            {
                return Ok(request.Data);
            }

            return BadRequest(new { errors = request.Errors });

        }
        [HttpPost]
        public async Task<IActionResult> AddAppSetting(RouteItem entity, CancellationToken cancellationToken)
        {
            var request = await _service.AddRouteItem(entity, cancellationToken);

            if (request.Success)
            {
                return Ok(request.Data);
            }

            return BadRequest(new { errors = request.Errors });

        }
        [HttpPut, Route("{entityId}")]
        public async Task<IActionResult> UpdateRouteItem(int entityId, [FromBody] RouteItem entity, CancellationToken cancellationToken)
        {
            entity.Id = entityId;
            var request = await _service.UpdateRouteItem(entity, cancellationToken);


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
        public async Task<IActionResult> DeleteRouteItem(int entityId, CancellationToken cancellationToken)
        {
            var request = await _service.DeleteRouteItem(entityId, cancellationToken);

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
}