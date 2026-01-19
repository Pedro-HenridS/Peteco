using Domain.Enum.Adoption;

namespace Domain.Entities
{
    public class AdoptionRequest
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public Guid UserId { get; set; }
        public AdoptionStatus Status { get; set; }
        public Guid? ReviewedByInstitutionUserId { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Dog Animal { get; set; } = null!;
    }
}
