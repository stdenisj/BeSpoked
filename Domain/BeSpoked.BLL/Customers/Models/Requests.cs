using BeSpoked.Common.EntityService.Models;

namespace BeSpoked.Customers.Models;

public sealed record CreateCustomerRequest : ICreateEntityRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    //public Address
    public required string Phone { get; set; }
};

public sealed record UpdateCustomerRequest : IUpdateEntityRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    //public Address
    public string? Phone { get; set; }
};