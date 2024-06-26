using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Feedback : BaseEntity
    {
        public int RestaurantId { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public virtual List<Response> Responses { get; set; }
    }
}
