using FluentValidation;
using MeetupApp.Request;

namespace MeetupApp.Validation
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEmpty().Length(1, 50).WithMessage(u => $"{nameof(u.Name)} shouldn't be null, empty or with invalid length!");
            RuleFor(u => u.Surname).NotNull().NotEmpty().Length(1, 50).WithMessage(u => $"{nameof(u.Surname)} shouldn't be null, empty or with invalid length!");
            RuleFor(u => u.Login).NotNull().NotEmpty().Length(5, 50).WithMessage(u => $"{nameof(u.Login)} shouldn't be null, empty or with invalid lenght!");
        }
    }
}
