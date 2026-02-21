using Volunteer.Domain.Entities;
using Volunteer.Domain.Entities.Animals;
using Volunteer.Domain.Entities.Users;
using Volunteer.Domain.ValueObjects;

namespace Volunteer.Domain.Entities.Profiles;

public sealed class AdopterProfile : BaseEntity
{
    public Guid UserId { get; init; }
    public User User {get; set;}
    public Location? Address { get; set; }
    public string? FamilyInfo { get; set; }
    public string? Experience { get; set; }
    public string? Availability { get; set; }
    public string? Notes { get; set; }
    
    public List<Animal> Animals { get; private set; } = new();
}
