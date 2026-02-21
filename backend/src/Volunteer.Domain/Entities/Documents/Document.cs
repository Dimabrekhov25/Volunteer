using Volunteer.Domain.Entities;

namespace Volunteer.Domain.Entities.Documents;

public sealed class Document : BaseEntity
{
    public string Type { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public DateTimeOffset IssuedAt { get; set; }
    public DateTimeOffset? ExpiresAt { get; set; }
    public string FileUrl { get; set; } = string.Empty;
}
