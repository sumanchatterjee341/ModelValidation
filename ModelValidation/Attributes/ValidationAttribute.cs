using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ModelValidation.Models;
using ModelValidation.ModelValidators;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ModelValidation.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ValidationAttribute : Attribute, IAsyncActionFilter
    {
        private ILogger<ValidationAttribute> _logger;        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ValidationAttribute>>();            
            ValidationResult result = null;
            var requestObj = context.ActionArguments["request"];
            switch (requestObj.GetType().Name.ToString())
            {                
                case "Student":
                    result = await new StudentValidator().ValidateAsync((Student)requestObj);
                    break;
                default:
                    break;
            }
            if (!result.IsValid)
            {
                var resp = CreateResponse<Response>(result);
                context.Result = new BadRequestObjectResult(resp);
                _logger.LogInformation($"Result is : {JsonConvert.SerializeObject(resp)}");
                return;
            }
            await next();
        }
        protected T CreateResponse<T>(ValidationResult result) where T : new()
        {
            _ = Enum.TryParse(result.Errors[0].ErrorCode, out ErrorCode errorCode);
            var resp = new Response { ErrorMessage = result.Errors[0].ErrorMessage, ErrorCode = errorCode };
            if (resp != null)
            {
                return (T)Convert.ChangeType(resp, typeof(T));
            }
            return default;
        }        
    }
}
