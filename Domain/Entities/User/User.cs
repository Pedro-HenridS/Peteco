using Domain.Enum.Role;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [MaxLength(30)]
        public string Username { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;
        public Role Role { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;
        public DateTime LastLoginAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Address Address { get; set; } = null!;

        public ICollection<InstitutionUser> InstitutionUser { get; set; } = new List<InstitutionUser>();
        public ICollection<AdoptionRequest> AdoptionRequest { get; set; } = new List<AdoptionRequest>();
    }
}
