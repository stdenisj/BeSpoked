namespace BeSpoked.Sales.Models;

public sealed record SaleSummary(
    Guid SaleId,
    DateTime SaleDate,
    decimal SalePrice,
    string CustomerName,
    string SalesPersonName,
    decimal CommissionAmount,
    string ProductName,
    string ProductManufacturer
);