using BeSpoked.Common.Validators;
using BeSpoked.SalesTeam.Entities;
using FluentValidation;

namespace BeSpoked.SalesTeam.Validators;

public class SalesPersonValidator : AbstractValidator<SalesPerson>
{
    public SalesPersonValidator()
    {
        RuleFor(e => e.FirstName).NotEmpty().WithMessage("First name cannot be blank");
        RuleFor(e => e.LastName).NotEmpty().WithMessage("Last name cannot be blank");
        RuleFor(e => e.Phone).SetValidator(new PhoneNumberValidator());
        When(e => e.TerminationDate != null, () =>
        {
            RuleFor(e => e).Must(TerminationDateValid).WithMessage("Invalid termination date");
        });
        RuleFor(e => e.Manager).NotEmpty().WithMessage("Manager name required");
    }

    private static bool TerminationDateValid(SalesPerson person)
        => person.TerminationDate!.Value >= person.StartDate;
}