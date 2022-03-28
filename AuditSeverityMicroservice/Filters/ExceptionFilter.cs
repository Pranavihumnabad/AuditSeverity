using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuditSeverityMicroservice.Filters
{
    public class ExceptionFilter: ExceptionFilterAttribute, IExceptionFilter
    {
        private static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(ExceptionContext filterContext)
        {
            // filterContext.Result = new InternalServerErrorResult();
            _log4net.Error($"{filterContext.Exception.Message} : {System.Reflection.MethodBase.GetCurrentMethod().DeclaringType}");

            // Anonymous Object  --- without class
            var result = new
            {
                message = "There is server error. We resolve soon...",
                isError = true,
                errorMessage = filterContext.Exception.Message,
                errorCode = 500
            };

            filterContext.Result = new JsonResult(result);
            filterContext.ExceptionHandled = true;
        }
    }
}
