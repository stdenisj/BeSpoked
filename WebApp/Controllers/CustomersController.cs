using BeSpoked.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeSpoked.Api.Controllers;

[Route("/api/[controller]")]
public class CustomersController : BeSpokedBaseController
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers(CancellationToken cancellationToken)
    {
        var customers = await _customerService.GetAll(cancellationToken);
        return Success(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(Guid id, CancellationToken cancellationToken)
    {
        var customer = await _customerService.Get(id, cancellationToken);
        return Success(customer);
    }
}