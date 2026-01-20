using Domain.Enum.Role;

namespace Domain.Entities
{
    public class InstitutionUser
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid UserId { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public Institution Institution { get; set; } = null!;
        public User User { get; set; } = null!;
        public AdoptionRequest AdoptionRequest { get; set; } = null!;
    }
}
