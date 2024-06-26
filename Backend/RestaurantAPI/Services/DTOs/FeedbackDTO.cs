using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public List<ResponseDTO> Responses { get; set; }
    }
}
