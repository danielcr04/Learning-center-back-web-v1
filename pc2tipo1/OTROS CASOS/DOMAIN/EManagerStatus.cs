/*namespace si730pc2uXXXXXXX.API.CRM.Domain.Model.ValueObjects;

/// <summary>
/// Enumeration of possible manager statuses.
/// </summary>
public record EManagerStatus(int Id, string Name)
{
    public static readonly EManagerStatus Open = new(1, "Open");
    public static readonly EManagerStatus Contacted = new(2, "Contacted");
    public static readonly EManagerStatus MeetingSet = new(3, "MeetingSet");
    public static readonly EManagerStatus Qualified = new(4, "Qualified");
    public static readonly EManagerStatus Customer = new(5, "Customer");
    public static readonly EManagerStatus OpportunityLost = new(6, "OpportunityLost");
    public static readonly EManagerStatus Unqualified = new(7, "Unqualified");
    public static readonly EManagerStatus InVeterinaryCustomer = new(8, "InVeterinaryCustomer");

    public static IEnumerable<EManagerStatus> List() => new[]
    {
        Open, Contacted, MeetingSet, Qualified, Customer, OpportunityLost, Unqualified, InVeterinaryCustomer
    };

    public static EManagerStatus FromId(int id) =>
        List().FirstOrDefault(status => status.Id == id) ?? throw new ArgumentException("Invalid status id");

    public static EManagerStatus FromName(string name) =>
        List().FirstOrDefault(status => status.Name == name) ?? throw new ArgumentException("Invalid status name");

    public override string ToString() => Name;

}*/