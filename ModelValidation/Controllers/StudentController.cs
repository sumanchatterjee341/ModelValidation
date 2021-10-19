using Microsoft.AspNetCore.Mvc;
using ModelValidation.Attributes;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Validation]
    [LogReqResp]
    public class StudentController : ControllerBase
    {        
        [HttpPost]
        public Response Student(Student request) =>//Do Action 
            new() { SuccessIn = true };

    }
}
