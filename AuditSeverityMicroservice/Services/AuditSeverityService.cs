using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditSeverityMicroservice.Models;
using AuditSeverityMicroservice.Repository;
using AuditSeverityMicroservice.Filters;
namespace AuditSeverityMicroservice.Services
{
    [ExceptionFilter]
    public class AuditSeverityService : IAuditSeverityService
    {

        private readonly IAuditSeverityRepo _severityRepo;
        public readonly log4net.ILog log4netval = log4net.LogManager.GetLogger(typeof(AuditSeverityService));

        public AuditSeverityService(IAuditSeverityRepo _severityRepo)
        {
            this._severityRepo = _severityRepo;
        }
        public AuditResponse GetSeverityResponse(AuditRequest req, string token)
        {

            log4netval.Info(" GetSeverityResponse Method of AuditSeverityService Called ");


            List<BenchmarkResponseAuditType> BenchmarkResponseAuditTypeList = _severityRepo.GetResponse(token);

            int CaluclatedCount = 0;
            CaluclatedCount = req.Auditdetails.QuestionsList.Count(c => !c.Answer);



            BenchmarkResponseAuditType resolve = BenchmarkResponseAuditTypeList.Where(t => (t.AuditTypeId == req.Auditdetails.AuditTypeId) && (t.MinAcceptableValue <= CaluclatedCount) && (t.MaxAcceptableValue >= CaluclatedCount)).Single();
            Random randomNumber = new Random();

            AuditResponse auditResponse = new AuditResponse();

            auditResponse.AuditId = randomNumber.Next();
            auditResponse.RemedialActionDuration = resolve.RemedialAction;
            auditResponse.ProjectExecutionStatus = resolve.AuditResultStatus;

            return auditResponse;

        }

    }
}
