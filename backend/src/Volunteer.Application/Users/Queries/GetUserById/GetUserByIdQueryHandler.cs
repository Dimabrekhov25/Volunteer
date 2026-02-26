using System.Data;
using MediatR;
using Microsoft.VisualBasic;
using Volunteer.Application.Common.Interfaces;
using Volunteer.Application.Users.DTOs;

namespace Volunteer.Application.Users.Queries.GetById;

public class GetUserByIdQueryHandler(
    IUsersRepositories usersRepositories) 
    : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(
        GetUserByIdQuery userByIdRequest,
        CancellationToken cancellationToken)
    {
        var userResult = await usersRepositories.GetByIdAsync(
            userByIdRequest.id,
            cancellationToken);

        if (userResult is null)
        {
            throw new Exception("User not found");
        }

        return new UserDto(
            userResult.Email,
            userResult.Phone,
            userResult.FirstName,
            userResult.LastName,
            userResult.Status,
            userResult.Roles);
    }
}