using AuditSeverityMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityMicroservice.Services
{
    public interface IAuditSeverityService
    {
        public AuditResponse GetSeverityResponse(AuditRequest req, string token);

    }
}
