﻿using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Responses
{
    public class GetAllRestaurantsResponse
    {
        public List<RestaurantDTO> Restaurants { get; set; }
    }
}
