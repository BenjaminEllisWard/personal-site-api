using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models.Requests;
using Infrastructure.Models.Responses;
using Infrastructure.Services;

namespace myCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestbookController : ControllerBase
    {
        private readonly IGuestbookService _guestbookService;

        public GuestbookController(IGuestbookService guestbookService)
        {
            _guestbookService = guestbookService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _guestbookService.GetAsync().Result;

            var response = new GuestbookEntryGetResponse { Success = true, Entries = result };

            return Ok(response);
        }

        [HttpPost]
        public ActionResult Post(GuestbookEntryPostRequest request)
        {
            var success = _guestbookService.PostAsync(request);

            var response = new SuccessResponse { Success = success.Result };

            return Ok(response);
        }
    }
}