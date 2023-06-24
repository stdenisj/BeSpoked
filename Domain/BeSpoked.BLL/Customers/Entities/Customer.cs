using BeSpoked.Common.EntityService.Entities;
using BeSpoked.Sales.Entities;

namespace BeSpoked.Customers.Entities;

public record Customer : Entity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    //public Address
    public required string Phone { get; set; }
    public DateTime StartDate { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
};