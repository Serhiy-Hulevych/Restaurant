using Services.DTOs;
using Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFeedbackService
    {
        public Task<bool> AddFeedback(AddFeedbackRequest request);
        public Task<List<FeedbackDTO>> GetFeedbacksByRestaurant(int restaurantId);
        public Task<bool> IsValidFeedback(int feedbackId);
    }
}
