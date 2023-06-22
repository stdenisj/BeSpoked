using BeSpoked.Products.Entities;
using FluentValidation;

namespace BeSpoked.Products.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(e => e.Name).NotEmpty().WithMessage("Name cannot be blank");
        RuleFor(e => e.Manufacturer).NotEmpty().WithMessage("Manufacturer cannot be blank");
        RuleFor(e => e.SalePrice).GreaterThanOrEqualTo(0);
        RuleFor(e => e.PurchasePrice).GreaterThanOrEqualTo(0);
        RuleFor(e => e.CommissionPercentage).GreaterThanOrEqualTo(0);
        RuleFor(e => e.QuantityOnHand).GreaterThanOrEqualTo(0);
    }
}