using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Volunteer.Domain.Entities;
using Volunteer.Domain.Entities.Users;

namespace Volunteer.API.Controllers;



[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    [HttpGet]
    public ActionResult Get(string email, string firstName, string lastName, string phoneNumber)
    {
        var userResult = Domain.Entities.Users.User.Create(email, firstName, lastName, phoneNumber);
        if (userResult.IsFailure)
        {
            return ValidationProblem();
        }
        var result = Save(userResult.Value);
        if (result.IsFailure)
            return BadRequest(result.Error);
        
        return Ok(result);
    }
    
    public Result Save(User user)
    {
        if (true)
        {
            return Result.Success();
        }

        return Result.Failure("User is empty ");
    }
} 