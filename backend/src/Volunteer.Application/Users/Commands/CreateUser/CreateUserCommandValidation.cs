using FluentValidation;

namespace Volunteer.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidation()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("Email is required.");
        
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .WithMessage("FirstName is required.");
        
        RuleFor(c => c.LastName)
            .NotEmpty()
            .WithMessage("LastName is required.");
        
        RuleFor(c => c.Phone)
            .NotEmpty()
            .MaximumLength(10)
            .WithMessage("Phone is required.");
    }
}