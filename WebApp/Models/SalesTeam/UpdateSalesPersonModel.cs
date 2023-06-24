using BeSpoked.SalesTeam.Models;

namespace BeSpoked.Api.Models.SalesTeam;

public class UpdateSalesPersonModel
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Manager { get; set; }

    public UpdateSalesPersonRequest ToRequest() => new (FirstName, LastName, Phone, Manager, null);
}