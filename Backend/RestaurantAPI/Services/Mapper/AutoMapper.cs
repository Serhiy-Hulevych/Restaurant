using AutoMapper;
using Data.Entities;
using Services.DTOs;
using Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public class DTOsMapping : Profile
    {
        public DTOsMapping()
        {
            CreateMap<RestaurantDTO, Restaurant>().ReverseMap();
            CreateMap<FeedbackDTO, Feedback>().ReverseMap();
            CreateMap<ResponseDTO, Response>().ReverseMap();

            CreateMap<Restaurant, AddRestaurantRequest>().ReverseMap();
            CreateMap<Feedback, AddFeedbackRequest>().ReverseMap();
            CreateMap<Response, AddResponseRequest>().ReverseMap();
        }
    }
}
