using Services.DTOs;
using Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRestaurantService
    {
        public Task<bool> AddRestaurant(AddRestaurantRequest request);
        public Task<List<RestaurantDTO>> GetAllRestaurants();
        public Task<RestaurantDTO> GetRestaurantById(int id);
        public Task<bool> IsValidRestaurant(int id);
        public Task<bool> UpdateAverageRating(int restaurantId, double averageRating);
    }
}
