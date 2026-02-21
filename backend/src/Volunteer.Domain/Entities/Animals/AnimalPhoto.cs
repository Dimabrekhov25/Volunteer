using Volunteer.Domain.Entities;

namespace Volunteer.Domain.Entities.Animals;

public class AnimalPhoto : BaseEntity
{
    public string Path { get; set; } = string.Empty;
}
