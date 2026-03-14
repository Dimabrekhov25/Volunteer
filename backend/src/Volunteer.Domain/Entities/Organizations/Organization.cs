using Volunteer.Domain.Entities;
using Volunteer.Domain.Enums;
using Volunteer.Domain.ValueObjects;

namespace Volunteer.Domain.Entities.Organizations;

public class Organization : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Contact? Contact { get; set; }
    public Location? Address { get; set; }
    public Guid? ManagerUserId { get; set; }
    public OrganizationStatus Status { get; set; } = OrganizationStatus.Active;
}
