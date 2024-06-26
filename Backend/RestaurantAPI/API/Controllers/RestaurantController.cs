using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;
using Services.Requests;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService service)
        {
            _restaurantService = service;
        }

        [HttpGet]
        [Route("GetAllRestaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var res = await _restaurantService.GetAllRestaurants();

            return Ok(res);
        }

        [HttpGet]
        [Route("GetRestaurantById")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            RestaurantDTO res = await _restaurantService.GetRestaurantById(id);

            return Ok(res);
        }

        [HttpPost]
        [Route("AddRestaurant")]
        public async Task<IActionResult> AddRestaurant(AddRestaurantRequest request)
        {
            var res = await _restaurantService.AddRestaurant(request);

            return Ok(res);
        }
    }
}
