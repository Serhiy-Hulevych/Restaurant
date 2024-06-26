using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IFeedbackRepository : IBaseRepository<Feedback>
    {
        public Task<double> GetAverage(int restaurantId);
    }
}
