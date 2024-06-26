using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(RestaurantContext context) : base(context) { }

        public async Task<double> GetAverage(int restaurantId)
        {
            double res = await _context.Feedbacks.Where(x => x.RestaurantId == restaurantId).AverageAsync(x => x.Rating);
            return res;
        }
    }
}
