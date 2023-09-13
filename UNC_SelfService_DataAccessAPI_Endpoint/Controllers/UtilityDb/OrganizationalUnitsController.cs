using Microsoft.AspNetCore.Mvc;
using UNC.API.Base;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Controllers.UtilityDb
{
    [Route("v1/utilities-db/organizational-units")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "utilitiesDb")]
    public class OrganizationalUnitsController : BaseController
    {
        private readonly IOrganizationalUnitService _service;

        public OrganizationalUnitsController(ILogger<OrganizationalUnitsController> logger, IOrganizationalUnitService service) : base(logger)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAppSettings([FromQuery] OrganizationalUnitCriteria criteria, CancellationToken cancellationToken)
        {
            var request = await _service.GetOrganizationalUnits(criteria, cancellationToken);


            if (request.Success)
            {
                return Ok(request.Data);
            }

            return BadRequest(new { errors = request.Errors });

        }
        [HttpPost]
        public async Task<IActionResult> AddAppSetting([FromBody] OrganizationalUnit entity, CancellationToken cancellationToken)
        {
            var request = await _service.AddOrganizationalUnit(entity, cancellationToken);

            if (request.Success)
            {
                return Ok(request.Data);
            }

            return BadRequest(new { errors = request.Errors });

        }
        [HttpPut, Route("{entityId}")]
        public async Task<IActionResult> UpdateOrganizationalUnit(int entityId, [FromBody] OrganizationalUnit entity, CancellationToken cancellationToken)
        {
            entity.Id = entityId;
            var request = await _service.UpdateOrganizationalUnit(entity, cancellationToken);


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
        public async Task<IActionResult> DeleteOrganizationalUnit(int entityId, CancellationToken cancellationToken)
        {
            var request = await _service.DeleteOrganizationalUnit(entityId, cancellationToken);

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



        [HttpGet, Route("{entityId}/ou-admins")]
        public async Task<IActionResult> GetOrganizationalUnitAdmins(int entityId, [FromQuery] OrganizationalUnitAdminCriteria criteria,CancellationToken cancellationToken)
        {
            criteria.OrganizationalUnitId = entityId;
            var request = await _service.GetOrganizationalUnitAdmins(criteria, cancellationToken);


            if (request.Success)
            {
                return Ok(request.Data);
            }

            return BadRequest(new { errors = request.Errors });

        }



    }

}
