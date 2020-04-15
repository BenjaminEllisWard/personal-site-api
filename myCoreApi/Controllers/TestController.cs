using Infrastructure.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace myCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<SuccessResponse> Get()
        {
            return Ok(new SuccessResponse { Success = true });
        }
    }
}