using Volunteer.Domain.Entities;
using Volunteer.Domain.Entities.Deliveries;
using Volunteer.Domain.Entities.Documents;
using Volunteer.Domain.Entities.Profiles;
using Volunteer.Domain.Enums;
using Volunteer.Domain.ValueObjects;

namespace Volunteer.Domain.Entities.Animals;

public sealed class Animal : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public Guid? AdopterProfileId { get; set; }      
    public AdopterProfile? AdopterProfile { get; set; }
    public Guid VolunteerProfileId  { get; set; }
    public VolunteerProfile VolunteerProfile { get; set; }
    public List<DeliveryAnimal> DeliveryAnimals { get; set; } = new();
    public string? Breed { get; set; }
    public AnimalSex Sex { get; set; } = AnimalSex.Unknown;
    public DateOnly? BirthDate { get; set; }
    public AnimalSize Size { get; set; } = AnimalSize.Unknown;
    public string? Color { get; set; }
    public List<string> Traits { get; set; } = new();
    public AnimalMedicalStatus MedicalStatus { get; set; } = AnimalMedicalStatus.Unknown;
    public List<string> Vaccinations { get; set; } = new();
    public bool Sterilized { get; set; }
    public string? MicrochipId { get; set; }
    public List<AnimalPhoto> Photos { get; set; } = [];
    public List<Document> Documents { get; set; } = new();
    public Location? CurrentLocation { get; set; }
    public AnimalStatus Status { get; set; } = AnimalStatus.InShelter;
    public Guid? OwnerOrganizationId { get; set; }
}
