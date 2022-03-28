using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityMicroservice.Models
{
    
    public class BenchmarkResponseAuditType
    {
        [Key]
        public int Id { get; set; }
        public int AuditTypeId { get; set; }
        public int MinAcceptableValue { get; set; }
        public int MaxAcceptableValue { get; set; }
        public string AuditResultStatus { get; set; }
        public string RemedialAction { get; set; }

    }
}
