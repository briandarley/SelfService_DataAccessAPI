using Microsoft.AspNetCore.Mvc;
using UNC.API.Base;
using UNC.Models.Configurations;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "tests")]
    public class TestController : BaseController
    {
        private readonly IApiEndPoints _apiEndpoints;

        public TestController(ILogger<TestController> logger, IApiEndPoints apiEndpoints) : base(logger)
        {
            _apiEndpoints = apiEndpoints;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World!");
        }
        [HttpGet, Route("api-endpoints")]
        public IActionResult GetApiEndpoints()
        {
            return Ok(_apiEndpoints);
        }
    }
}
