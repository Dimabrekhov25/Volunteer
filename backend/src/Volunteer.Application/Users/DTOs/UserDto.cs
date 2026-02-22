using Volunteer.Domain.Enums;

namespace Volunteer.Application.Users.DTOs;

public record UserDto (
    string Email,
    string Phone,
    string FirstName,
    string LastName,
    UserStatus Status, 
    IReadOnlyCollection<UserRole> Roles); 