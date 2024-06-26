using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Requests;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IResponseService _responseService;

        public ResponseController(IResponseService responseService)
        {
            _responseService = responseService;
        }

        [HttpPost]
        [Route("AddResponse")]
        public async Task<IActionResult> AddResponse(AddResponseRequest request)
        {
            var res = await _responseService.AddResponse(request);

            return Ok(res);
        }
    }
}
