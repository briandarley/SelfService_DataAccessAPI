using Microsoft.AspNetCore.Mvc;
using UNC.API.Base;

namespace UNC_SelfService_DataAccessAPI_Endpoint.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "tests")]
    public class TestController : BaseController
    {
        public TestController(ILogger<TestController> logger) : base(logger)
        {
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World!");
        }
    }
}
