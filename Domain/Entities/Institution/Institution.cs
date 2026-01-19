using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Institution
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(15)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(30)]
        public string Cnpj { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        [MaxLength(200)]
        public string WebSite { get; set; } = string.Empty;
        public Guid AdressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Address> Address { get; set; } = new List<Address>();
        public ICollection<Dog> Dogs { get; set; } = new List<Dog>();
        public ICollection<InstitutionUser> InstitutionUser { get; set; } = new List<InstitutionUser>();
    }
}
