using CSharpFunctionalExtensions;
using Volunteer.Domain.Entities;
using Volunteer.Domain.Enums;

namespace Volunteer.Domain.Entities.Users;

public sealed class User : BaseEntity
{
    public User()
    {
    }

    private User(string email, string firstName, string lastName, string phoneNumber)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Phone =  phoneNumber;
    }
    
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string FirstName { get;  set; } = string.Empty;
    public string LastName { get;  set; } = string.Empty;
    public UserStatus Status { get; set; } = UserStatus.Active;
    public List<UserRole> Roles { get; set; } = new();
    public DateTimeOffset? LastLoginAt { get; set; }
    
    
    public static Result<User> Create(string email, string firstName, string lastName, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return Result.Failure<User>("Email is required");
        }
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<User>("FirstName is required");
        }
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<User>("LastName is required");
        }
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            return Result.Failure<User>("PhoneNumber is required");
        }
        var user = new User(email, firstName, lastName, phoneNumber);
        
        return Result.Success(user);
    }
    
    
}
