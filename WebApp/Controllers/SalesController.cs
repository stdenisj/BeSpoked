using BeSpoked.Api.Models.Sales;
using BeSpoked.Sales.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeSpoked.Api.Controllers;

[Route("/api/[controller]")]
public class SalesController : BeSpokedBaseController
{
    private readonly ISalesService _saleService;
    private readonly ISalesManager _salesManager;

    public SalesController(ISalesService saleService, ISalesManager salesManager)
    {
        _saleService = saleService;
        _salesManager = salesManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSalesSummaries(CancellationToken cancellationToken)
    {
        var sales = await _saleService.GetSalesSummaries(cancellationToken);
        return Success(sales);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSale(Guid id, CancellationToken cancellationToken)
    {
        var sale = await _saleService.Get(id, cancellationToken);
        return Success(sale);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSale(CreateSaleModel model, CancellationToken cancellationToken)
    {
        var sale = await _salesManager.RecordSale(model.ToRequest(), cancellationToken);
        return Success(sale);
    }
}