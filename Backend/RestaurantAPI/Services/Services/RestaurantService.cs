using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Services.DTOs;
using Services.Interfaces;
using Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddRestaurant(AddRestaurantRequest request)
        {
            try
            {
                Restaurant existingRestaurant = await _restaurantRepository.FirstOrDefault(x => x.Name.ToLower() == request.Name.ToLower());
                if (existingRestaurant is not null)
                {
                    throw new ArgumentException($"A restaurant with the name '{request.Name}' already exists.");
                }

                Restaurant restaurant = _mapper.Map<Restaurant>(request);
                await _restaurantRepository.Add(restaurant);
                return true;
            }
            catch(ArgumentException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new ArgumentException($"Internal error adding the restaurant.");
            }
        }

        public async Task<List<RestaurantDTO>> GetAllRestaurants()
        {
            try
            {
                List<Restaurant> restaurants = (await _restaurantRepository.GetAll()).ToList();
                List<RestaurantDTO> res = _mapper.Map<List<RestaurantDTO>>(restaurants);

                return res;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Internal error while getting the restaurants.");
            }
        }

        public async Task<RestaurantDTO> GetRestaurantById(int id)
        {
            try
            {
                Restaurant restaurant = await _restaurantRepository.GetById(id);
                RestaurantDTO res = _mapper.Map<RestaurantDTO>(restaurant);

                return res;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Internal error while getting the restaurant details.");
            }
        }

        public async Task<bool> IsValidRestaurant(int id)
        {
            try
            {
                Restaurant restaurant = await _restaurantRepository.GetById(id);

                return restaurant is not null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Internal error while validating restaurant.");
            }
        }

        public async Task<bool> UpdateAverageRating(int restaurantId, double averageRating)
        {
            try
            {
                Restaurant restaurant = await _restaurantRepository.GetById(restaurantId);
                if (restaurant is not null)
                {
                    restaurant.AverageRating = averageRating;
                    await _restaurantRepository.Update(restaurant);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Internal error while validating restaurant.");
            }
        }
    }
}
