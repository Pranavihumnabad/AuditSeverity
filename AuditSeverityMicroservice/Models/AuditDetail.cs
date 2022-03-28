using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityMicroservice.Models
{
    public class AuditDetail
    {
        public int AuditTypeId { get; set; }
        public string Date { get; set; }
        public List<Questions> QuestionsList { get; set; }

    }
}
