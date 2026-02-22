using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Volunteer.Application.Users.Commands.CreateUser;
using Volunteer.Application.Users.DTOs;
using Volunteer.Domain.Entities;
using Volunteer.Domain.Entities.Users;

namespace Volunteer.API.Controllers;



public class UserController(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserCommand createUserCommand,
        CancellationToken cancellationToken)
    {
        var userResult = await mediator.Send(createUserCommand, cancellationToken);
        return OkResult(userResult);
    }
  
} 