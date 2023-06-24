using BeSpoked.Sales.Entities;
using FluentValidation;

namespace BeSpoked.Sales.Validators;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(e => e.CustomerId).NotEmpty().NotEqual(Guid.Empty).WithMessage("Invalid customer");
        RuleFor(e => e.ProductId).NotEmpty().NotEqual(Guid.Empty).WithMessage("Invalid product");
        RuleFor(e => e.SalesPersonId).NotEmpty().NotEqual(Guid.Empty).WithMessage("Invalid sales person");
        RuleFor(e => e.CommissionAmount).GreaterThanOrEqualTo(0M);
    }
}