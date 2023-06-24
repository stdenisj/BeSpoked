using BeSpoked.Common;
using BeSpoked.Products.Interfaces;
using BeSpoked.Products.Models;
using BeSpoked.Sales.Interfaces;
using BeSpoked.Sales.Models;

namespace BeSpoked.Sales;

public class SalesManager : ISalesManager
{
    private readonly ISalesService _salesService;
    private readonly IProductService _productService;

    public SalesManager(ISalesService salesService, IProductService productService)
    {
        _salesService = salesService;
        _productService = productService;
    }

    public async Task<SaleSummary> RecordSale(RecordSaleRequest request, CancellationToken cancellationToken = default)
    {
        var product = await _productService.Get(request.ProductId, cancellationToken);

        if (product.QuantityOnHand == 0)
        {
            var errors = new List<ModelValidationError> { new("ProductId", "Product not available") };
            throw new ModelValidationException(errors);
        }
        
        var updateProductRequest = new UpdateProductRequest() { QuantityOnHand = --product.QuantityOnHand };

        await _productService.Update(product, updateProductRequest, cancellationToken);
        
        var commissionAmount = decimal.Round(product.SalePrice * product.CommissionPercentage, 2, MidpointRounding.ToEven);

        var createSaleRequest = new CreateSaleRequest()
        {
            CommissionAmount = commissionAmount, 
            CustomerId = request.CustomerId, 
            ProductId = request.ProductId,
            SalesPersonId = request.SalesPersonId,
            SalesPrice = product.SalePrice
        };

        var sale = await _salesService.Create(createSaleRequest, cancellationToken);

        return await _salesService.GetSaleSummary(sale.Id, cancellationToken);
    }
}