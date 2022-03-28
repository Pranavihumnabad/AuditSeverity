using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityMicroservice.Models
{
    public class AuditTypeMaster
    {
        public string AuditType { get; set; }
        public int MinAcceptableValue { get; set; }
        public int MaxAcceptableValue { get; set; }
        public string AuditResultStatus { get; set; }
        public string RemedialAction { get; set; }


    }
}
