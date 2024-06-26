using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Services.Interfaces;
using Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ResponseService : IResponseService
    {
        private readonly IResponseRepository _responseRepository;
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;

        public ResponseService(IResponseRepository responseRepository, IFeedbackService feedbackService, IMapper mapper)
        {
            _responseRepository = responseRepository;
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        public async Task<bool> AddResponse(AddResponseRequest request)
        {
            try
            {
                bool isValidFeedback = await _feedbackService.IsValidFeedback(request.FeedbackId);
                if (isValidFeedback)
                {
                    Response response = _mapper.Map<Response>(request);
                    await _responseRepository.Add(response);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Internal error adding the response.");
            }
        }
    }
}
