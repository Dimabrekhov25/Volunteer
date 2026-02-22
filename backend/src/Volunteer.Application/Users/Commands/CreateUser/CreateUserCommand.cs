using MediatR;
using Volunteer.Application.Users.DTOs;
using Volunteer.Domain.Enums;

namespace Volunteer.Application.Users.Commands.CreateUser;

public record CreateUserCommand(
    string Email,
    string Phone,
    string FirstName,
    string LastName,
    UserStatus Status, 
    IReadOnlyCollection<UserRole> Roles,
    DateTimeOffset? LastLoginAt ) : IRequest<UserDto>;
