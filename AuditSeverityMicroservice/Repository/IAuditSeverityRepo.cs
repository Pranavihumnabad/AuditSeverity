using AuditSeverityMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityMicroservice.Repository
{
    public interface IAuditSeverityRepo
    {
        public List<BenchmarkResponseAuditType> GetResponse(string token);
    }
}
