using BeSpoked.Common.Validators;
using BeSpoked.Customers.Entities;
using FluentValidation;

namespace BeSpoked.Customers.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(e => e.FirstName).NotEmpty().WithMessage("First name cannot be blank");
        RuleFor(e => e.LastName).NotEmpty().WithMessage("Last name cannot be blank");
        RuleFor(e => e.Phone).SetValidator(new PhoneNumberValidator());
    }
}