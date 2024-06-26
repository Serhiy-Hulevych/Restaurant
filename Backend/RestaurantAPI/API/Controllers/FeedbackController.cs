using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;
using Services.Requests;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        [Route("GetFeedbacksByRestaurant")]
        public async Task<ActionResult> GetFeedbacksByRestaurant(int restaurantId)
        {
            List<FeedbackDTO> res = await _feedbackService.GetFeedbacksByRestaurant(restaurantId);

            return Ok(res);
        }

        [HttpPost]
        [Route("SubmitFeedback")]
        public async Task<ActionResult> SubmitFeedback(AddFeedbackRequest request)
        {
            var res = await _feedbackService.AddFeedback(request);

            return Ok(res);
        }
    }
}
