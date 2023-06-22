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

public record UpdateSalesPersonRequest : IUpdateEntityRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    //public Address
    public string? Phone { get; set; }
    public string? Manager { get; set; }
    public DateTime? TerminationDate { get; set; }
};