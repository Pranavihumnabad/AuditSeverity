using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditSeverityMicroservice.Models;
using AuditSeverityMicroservice.Services;
using AuditSeverityMicroservice.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AuditSeverityMicroservice.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class AuditSeverityController : ControllerBase
    {
        private readonly IAuditSeverityService _severityService;
        public readonly log4net.ILog log4netval = log4net.LogManager.GetLogger(typeof(AuditSeverityController));
        public AuditSeverityController(IAuditSeverityService _severityService)
        {
            this._severityService = _severityService;
        }
        [HttpGet]
        public IActionResult GetProjectExecutionStatus()
        {
            log4netval.Info(" Http GET Request From: " + nameof(AuditSeverityController));

            return Ok("SUCCESS");
        }

        [HttpPost]
        public IActionResult GetProjectExecutionStatus([FromBody] AuditRequest request)
        {
            log4netval.Info(" Http POST Request From: " + nameof(AuditSeverityController));

            if (request == null)
                return BadRequest();

            else
            {

                string token = HttpContext.Request.Headers["Authorization"].Single().Split(" ")[1];
                AuditResponse Response = _severityService.GetSeverityResponse(request, token);


                return Ok(Response);

            }
        }
    }
}
