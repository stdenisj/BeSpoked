using BeSpoked.Sales.Entities;
using FluentValidation;

namespace BeSpoked.Sales.Validators;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(e => e.CustomerId).NotEqual(Guid.Empty).WithMessage("Invalid customer");
        RuleFor(e => e.ProductId).NotEqual(Guid.Empty).WithMessage("Invalid product");
        RuleFor(e => e.SalesPersonId).NotEqual(Guid.Empty).WithMessage("Invalid sales person");
    }
}