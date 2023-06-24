using BeSpoked.Common.EntityService.Models;

namespace BeSpoked.SalesTeam.Models;

public record CreateSalesPersonRequest : ICreateEntityRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    //public Address
    public required string Phone { get; set; }
    public required string Manager { get; set; }
};

public record UpdateSalesPersonRequest(
    string? FirstName,
    string? LastName,
    string? Phone,
    string? Manager,
    DateTime? TerminationDate
) : IUpdateEntityRequest;