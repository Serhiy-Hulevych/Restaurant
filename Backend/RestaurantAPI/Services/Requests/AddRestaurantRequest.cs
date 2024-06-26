using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Requests
{
    public class AddRestaurantRequest
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Location { get; set; }
        [Required, MaxLength(50)]
        public string CreatedBy { get; set; }
    }
}
