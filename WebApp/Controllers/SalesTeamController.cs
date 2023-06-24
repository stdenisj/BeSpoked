using BeSpoked.Api.Models.SalesTeam;
using BeSpoked.Customers.Interfaces;
using BeSpoked.SalesTeam.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeSpoked.Api.Controllers;

[Route("/api/[controller]")]
public class SalesTeamController : BeSpokedBaseController
{
    private readonly ISalesPersonService _salesPersonService;

    public SalesTeamController(ISalesPersonService salesPersonService)
    {
        _salesPersonService = salesPersonService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSalesPeople(CancellationToken cancellationToken)
    {
        var salesPeople = await _salesPersonService.GetAll(cancellationToken);
        return Success(salesPeople);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSalesPerson(Guid id, CancellationToken cancellationToken)
    {
        var salesPerson = await _salesPersonService.Get(id, cancellationToken);
        return Success(salesPerson);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSalesPerson(UpdateSalesPersonModel model, CancellationToken cancellationToken)
    {
        var salesPerson = await _salesPersonService.Get(model.Id, cancellationToken);
        var updatedSalesPerson = await _salesPersonService.Update(salesPerson, model.ToRequest(), cancellationToken);
        return Success(updatedSalesPerson);
    }
}