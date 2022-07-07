using FluentValidation;
using MeetupApp.Request;

namespace MeetupApp.Validation
{
    public class EventRequestValidator : AbstractValidator<EventRequest>
    {
        public EventRequestValidator()
        {
            RuleFor(e => e.Name).NotNull().NotEmpty().Length(1, 150).WithMessage(e => $"{nameof(e.Name)} shouldn't be null, empty or with invalid length!");
            RuleFor(e => e.Description).NotNull().NotEmpty().Length(1, 255).WithMessage(e => $"{nameof(e.Description)} shouldn't be null, empty or with invalid length!");
            RuleFor(e => e.Plan).NotNull().NotEmpty().Length(1, 255).WithMessage(e => $"{nameof(e.Plan)} shouldn't be null, empty or with invalid length!");
            RuleFor(e => e.Organizer).NotNull().NotEmpty().Length(1, 150).WithMessage(e => $"{nameof(e.Organizer)} shouldn't be null, empty or with invalid length!");
            RuleFor(e => e.Place).NotNull().NotEmpty().Length(1, 100).WithMessage(e => $"{nameof(e.Place)} shouldn't be null, empty or with invalid length!");
            RuleFor(e => e.DateOfEvent).NotNull().Must(IsValidDate).WithMessage(e => $"{nameof(e.DateOfEvent)} should be planed in future!");
            RuleFor(e => e.Speakers).NotNull().WithMessage(e => $"{nameof(e.Speakers)} should contain at least one spaeker!");
        }

        private bool IsValidDate(DateTime dateTime)
        {
            if (dateTime <= DateTime.Now)
            {
                return false;
            }

            return true;
        }
    }
}
