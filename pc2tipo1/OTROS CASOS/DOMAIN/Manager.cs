/*
using Pc2_Tipo1.API.CRM.Domain.Model.Commands;
using Pc2_Tipo1.API.CRM.Domain.Model.ValueObjects;

namespace Pc2_Tipo1.API.CRM.Domain.Model.Aggregates;

public partial class Manager
{
    public int Id { get; private set; }
    public Guid VeterinaryCampaignManagerId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Status { get; private set; }
    public int? AssignedSalesAgentId { get; private set; }
    public DateOnly? ContactedAt { get; private set; }
    public DateOnly? ApprovedAt { get; private set; }
    public DateOnly? ReportedAt { get; private set; }

    public Manager(CreateManagerCommand command)
    {
        ValidateBusinessRules(command);

        VeterinaryCampaignManagerId = Guid.NewGuid();
        FirstName = command.FirstName!;
        LastName = command.LastName!;
        Status = command.Status ?? EManagerStatus.Open.Id;
        AssignedSalesAgentId = command.AssignedSalesAgentId;
        ContactedAt = command.ContactedAt;
        ApprovedAt = command.ApprovedAt;
        ReportedAt = command.ReportedAt;
    }

    public Manager() { }

    private static void ValidateBusinessRules(CreateManagerCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.FirstName))
            throw new ArgumentException("First name is required");

        if (command.FirstName.Length < 4 || command.FirstName.Length > 40)
            throw new ArgumentException("First name must be between 4 and 40 characters");

        if (string.IsNullOrWhiteSpace(command.LastName))
            throw new ArgumentException("Last name is required");

        if (command.LastName.Length < 4 || command.LastName.Length > 40)
            throw new ArgumentException("Last name must be between 4 and 40 characters");

        var statusId = command.Status ?? EManagerStatus.Open.Id;

        if (!EManagerStatus.IsValid(statusId))
            throw new ArgumentException("Invalid manager status");

        if (statusId is 2 or 3 or 4 or 5 or 6 or 7 or 8)
        {
            if (!command.AssignedSalesAgentId.HasValue)
                throw new ArgumentException("Assigned Sales Agent ID is required for this status");

            if (!command.ContactedAt.HasValue)
                throw new ArgumentException("ContactedAt is required for this status");
        }

        if (statusId is 4 or 5 or 6 or 7 or 8)
        {
            if (!command.ApprovedAt.HasValue)
                throw new ArgumentException("ApprovedAt is required for this status");
        }

        if (statusId == 7 && !command.ReportedAt.HasValue)
        {
            throw new ArgumentException("ReportedAt is required for status 'Unqualified'");
        }
    }
}
*/
