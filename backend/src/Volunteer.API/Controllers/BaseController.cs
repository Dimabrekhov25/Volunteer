using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Workers.Api.Models;

namespace Volunteer.API.Controllers;



[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected IActionResult OkResult<T>(T data)
    {
        return Ok(ApiResult.Success(data));
    }

    protected IActionResult BadRequestResult(string massege)
    {
        return BadRequest(ApiResult.Failure(massege));
    }
    
    
}