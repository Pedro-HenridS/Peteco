using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid UserId { get; set; }
        [MaxLength(100)]
        public string Street { get; set; } = string.Empty;
        [MaxLength(20)]
        public string Number { get; set; } = string.Empty;
        [MaxLength(25)]
        public string Complement { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Neighborhood { get; set; } = string.Empty;
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;
        [MaxLength(50)]
        public string State { get; set; } = string.Empty;
        [MaxLength(50)]
        public string ZipCode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Institution Institution { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
