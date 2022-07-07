using FluentValidation;
using MeetupApp.Request;

namespace MeetupApp.Validation
{
    public class SpeakerRequestValidator : AbstractValidator<SpeakerRequest>
    {
        public SpeakerRequestValidator()
        {
            RuleFor(s => s.Name).NotNull().NotEmpty().Length(1, 50).WithMessage(s => $"{nameof(s.Name)} shouldn't be null, empty or with invalid length!");
            RuleFor(s => s.Surname).NotNull().NotEmpty().Length(1, 50).WithMessage(s => $"{nameof(s.Surname)} shouldn't be null, empty or with invalid length!");
        }
    }
}
