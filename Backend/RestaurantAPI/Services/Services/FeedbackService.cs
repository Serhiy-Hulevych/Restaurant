using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
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
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepository feedbackRepository, IRestaurantService restaurantService,IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        public async Task<bool> AddFeedback(AddFeedbackRequest request)
        {
            try
            {
                bool isValidRestaurant = await _restaurantService.IsValidRestaurant(request.RestaurantId);
                if(isValidRestaurant)
                {
                    await _feedbackRepository.ExecuteInTransaction(async () =>
                    {
                        Feedback feedback = _mapper.Map<Feedback>(request);
                        await _feedbackRepository.Add(feedback);

                        double averageRating = await _feedbackRepository.GetAverage(request.RestaurantId);
                        await _restaurantService.UpdateAverageRating(request.RestaurantId, averageRating);
                    });

                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Internal error submitting the feedback.");
            }
        }

        public async Task<List<FeedbackDTO>> GetFeedbacksByRestaurant(int restaurantId)
        {
            try
            {
                List<Feedback> feedbacks = (await _feedbackRepository.Where(x => x.RestaurantId == restaurantId)).ToList();
                List<FeedbackDTO> res = _mapper.Map<List<FeedbackDTO>>(feedbacks);

                return res;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Internal error while getting the feedbacks.");
            }
        }

        public async Task<bool> IsValidFeedback(int feedbackId)
        {
            try
            {
                Feedback feedback = await _feedbackRepository.GetById(feedbackId);

                return feedback is not null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Internal error while validating the feedback.");
            }
        }
    }
}
