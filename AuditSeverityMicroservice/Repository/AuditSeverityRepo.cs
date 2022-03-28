using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AuditSeverityMicroservice.Models;
using Newtonsoft.Json;
using AuditSeverityMicroservice.Filters;
using System.Net.Http.Headers;

namespace AuditSeverityMicroservice.Repository
{
    [ExceptionFilter]
    public class AuditSeverityRepo : IAuditSeverityRepo
    {
        public readonly log4net.ILog log4netval = log4net.LogManager.GetLogger(typeof(AuditSeverityRepo));

        public List<BenchmarkResponseAuditType> GetResponse(string token)
        {
            log4netval.Info(" GetResponse Method of AuditSeverityRepo Called ");
            List<BenchmarkResponseAuditType> BenchmarkResponseAuditTypeList = new List<BenchmarkResponseAuditType>();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44345/api/AuditBenchMark");
                var responseTask = client.GetAsync("AuditBenchMark");
                responseTask.Wait();
                var result = responseTask.Result;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                if (result.IsSuccessStatusCode)
                {

                    string jsonData = result.Content.ReadAsStringAsync().Result;

                    BenchmarkResponseAuditTypeList = JsonConvert.DeserializeObject<List<BenchmarkResponseAuditType>>(jsonData);


                }

            };

            return BenchmarkResponseAuditTypeList;

        }


    }
}
