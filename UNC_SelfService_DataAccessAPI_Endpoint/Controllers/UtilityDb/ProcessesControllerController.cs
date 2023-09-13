using Microsoft.AspNetCore.Mvc;
using UNC.API.Base;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Controllers.UtilityDb
{
    [Route("v1/utilities-db/processes")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "utilitiesDb")]
    public class ProcessesControllerController : BaseController
    {
        private readonly IProcessService _service;

        public ProcessesControllerController(ILogger<ProcessesControllerController> logger, IProcessService service) : base(logger)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetProcesses([FromQuery] ProcessCriteria criteria, CancellationToken cancellationToken)
        {
            var request = await _service.GetProcesses(criteria, cancellationToken);

            if (request.Success)
            {
                return Ok(request.Data);
            }

            return BadRequest(new { errors = request.Errors });

        }
        [HttpPost]
        public async Task<IActionResult> AddProcess(Process entity, CancellationToken cancellationToken)
        {
            var request = await _service.AddProcess(entity, cancellationToken);

            if (request.Success)
            {
                return Ok(request.Data);
            }

            return BadRequest(new { errors = request.Errors });

        }
        [HttpPut, Route("{entityId}")]
        public async Task<IActionResult> UpdateProcess(int entityId, [FromBody] Process entity, CancellationToken cancellationToken)
        {
            entity.Id = entityId;
            var request = await _service.UpdateProcess(entity, cancellationToken);


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
        public async Task<IActionResult> DeleteProcess(int entityId, CancellationToken cancellationToken)
        {
            var request = await _service.DeleteProcess(entityId, cancellationToken);

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
}
