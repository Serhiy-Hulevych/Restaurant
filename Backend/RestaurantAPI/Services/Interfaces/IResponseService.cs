using Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IResponseService
    {
        public Task<bool> AddResponse(AddResponseRequest request);
    }
}
