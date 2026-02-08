using CSharpFunctionalExtensions;
using Volunteer.Domain.Enums;

namespace Volunteer.Domain.Entities;

public sealed class Users
{
    public Users()
    {
    }

    private Users(string email, string firstName, string lastName, string phoneNumber)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Phone =  phoneNumber;
    }
    
    public Guid Id { get; init; }
    public string Email { get; private set; } = string.Empty;
    public string Phone { get;private set; } = string.Empty;
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public UserStatus Status { get; set; } = UserStatus.Active;
    public List<UserRole> Roles { get; set; } = new();
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? LastLoginAt { get; set; }
    
    
    public static Result<Users> Create(string email, string firstName, string lastName, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return Result.Failure<Users>("Email is required");
        }
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<Users>("FirstName is required");
        }
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<Users>("LastName is required");
        }
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            return Result.Failure<Users>("PhoneNumber is required");
        }
        var user = new Users(email, firstName, lastName, phoneNumber);
        
        return Result.Success(user);
    }
    
    
}
