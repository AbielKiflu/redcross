using AdaTranslation.Application.Features.Users.Dtos;

using FluentValidation;

namespace AdaTranslation.Application.Features.Users.Commands.CreateUser
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(x => x.Telephone)
                .Matches(@"^\+?\d{9,15}$").WithMessage("Telephone must be a valid format.");

            RuleFor(x => x.CenterId)
                .GreaterThan(0).WithMessage("A valid Center ID is required.");

            RuleFor(x => x.UserRole)
            .IsInEnum()
            .WithMessage("Invalid user role specified.");

            // Rule 6: Conditional Validation for Pause Dates
            //When(x => x.PauseStartDate.HasValue, () =>
            //{
            //    RuleFor(x => x.PauseEndDate)
            //        .NotNull().WithMessage("Pause End Date is required if Start Date is set.")
            //        .GreaterThan(x => x.PauseStartDate.Value)
            //        .WithMessage("Pause End Date must be after the Start Date.");
            //});
        }
    }
}
