namespace BeSpoked.Common.EntityService.Entities;

public abstract record Entity
{
    public Guid Id { get; set; }
}