using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ModelValidation.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ModelValidation.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LogReqRespAttribute : Attribute, IActionFilter
    {
        private ILogger<LogReqRespAttribute> _logger;
        private static Helper _helper;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _helper = context.HttpContext.RequestServices.GetRequiredService<Helper>();
            _logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<LogReqRespAttribute>>();            
            var requestObj = (ObjectResult)context.Result;
            JObject jObject = JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(requestObj.Value));
            //if (jObject != null)
            //{
            //    _helper.RemoveIds(jObject, new string[] { "errorcode" });
            //}
            _logger.LogInformation($"Response Message: { JsonConvert.SerializeObject(jObject)}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _helper = context.HttpContext.RequestServices.GetRequiredService<Helper>();
            _logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<LogReqRespAttribute>>();            
            var requestObj = context.ActionArguments["request"];
            JObject jObject = JsonConvert.DeserializeObject<JObject>(JsonConvert.SerializeObject(requestObj));
            //if (jObject != null)
            //{
            //    _helper.RemoveIds(jObject, new string[] { "firstname" });
            //}
            _logger.LogInformation($"Request Message: { JsonConvert.SerializeObject(jObject)}");
        }
    }
}
