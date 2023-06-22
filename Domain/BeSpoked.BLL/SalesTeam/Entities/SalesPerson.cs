using BeSpoked.Common.EntityService.Entities;
using BeSpoked.Sales.Entities;

namespace BeSpoked.SalesTeam.Entities;

public record SalesPerson : Entity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    //public Address
    public required string Phone { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    public required string Manager { get; set; }
    
    public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
};