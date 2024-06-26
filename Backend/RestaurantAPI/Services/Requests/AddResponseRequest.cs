using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Requests
{
    public class AddResponseRequest
    {
        public int FeedbackId { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required, MaxLength(50)]
        public string CreatedBy { get; set; }
    }
}
