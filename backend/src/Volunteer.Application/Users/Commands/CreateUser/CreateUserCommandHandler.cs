using MediatR;
using Volunteer.Application.Common.Interfaces;
using Volunteer.Application.Users.DTOs;
using Volunteer.Domain.Entities.Users;
using Volunteer.Domain.Enums;

namespace Volunteer.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(
    IUsersRepositories usersRepositories,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand,Guid>
{
    public async Task<Guid> Handle(
        CreateUserCommand createUserRequest,
        CancellationToken cancellationToken)
    {
        var userRequest = new User
        {
            Email = createUserRequest.Email,
            Phone = createUserRequest.Phone,
            FirstName = createUserRequest.FirstName,
            LastName = createUserRequest.LastName,
            Status = createUserRequest.Status,
            Roles = createUserRequest.Roles?.ToList(),
            LastLoginAt = createUserRequest.LastLoginAt
             };
        
        usersRepositories.Add(userRequest);

        unitOfWork.SaveChangesAsync(cancellationToken);
        
        return userRequest.Id;
    }
}