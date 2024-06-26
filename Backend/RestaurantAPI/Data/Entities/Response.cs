using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Response : BaseEntity
    {
        public int FeedbackId { get; set; }
        public string Answer { get; set; }
    }
}
