using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Requests
{
    public class AddFeedbackRequest
    {
        public int RestaurantId { get; set; }
        [Required, Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
        public string? Comments { get; set; }
        [Required, MaxLength(50)]
        public string CreatedBy { get; set; }
    }
}
