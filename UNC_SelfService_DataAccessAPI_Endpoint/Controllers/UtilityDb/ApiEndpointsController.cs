using Microsoft.AspNetCore.Mvc;
using UNC.API.Base;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Controllers.UtilityDb
{
    [Route("v1/utilities-db/api-endpoints")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "utilitiesDb")]
    public class ApiEndpointsController : BaseController
    {
        private readonly IUtilityDbService _service;

        public ApiEndpointsController(ILogger<ApiEndpointsController> logger, IUtilityDbService service) : base(logger)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAppSettings([FromQuery]ApiEndpointCriteria criteria, CancellationToken cancellationToken)
        {
            var request = await _service.GetApiEndpoints(criteria,cancellationToken);

            if (request.Success)
            {
                return Ok(request.Data);
            }

            return BadRequest(new { errors = request.Errors });

        }
        [HttpPost]
        public async Task<IActionResult> AddAppSetting(ApiEndpoint entity, CancellationToken cancellationToken)
        {
            var request = await _service.AddApiEndpoint(entity, cancellationToken);

            if (request.Success)
            {
                return Ok(request.Data);
            }

            return BadRequest(new { errors = request.Errors });

        }
        [HttpPut, Route("{entityId}")]
        public async Task<IActionResult> UpdateApiEndpoint(int entityId, [FromBody] ApiEndpoint entity, CancellationToken cancellationToken)
        {
            entity.Id = entityId;
            var request = await _service.UpdateApiEndpoint(entity, cancellationToken);


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
        public async Task<IActionResult> DeleteApiEndpoint(int entityId, CancellationToken cancellationToken)
        {
            var request = await _service.DeleteApiEndpoint(entityId, cancellationToken);

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