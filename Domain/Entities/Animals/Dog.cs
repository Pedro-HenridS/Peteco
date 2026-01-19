using Domain.Enum.Adoption;
using Domain.Enum.Gender;
using Domain.Enum.Health;
using Domain.Enum.Size;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Animals
{
    public class Dog
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }
        public DogSizeEnum Size { get; set; }
        [MaxLength(50)]
        public string Breed { get; set; } = string.Empty;
        [MaxLength(50)]
        public string Color { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        public HealthEnum HealthStatus { get; set; }
        public bool IsNeutered { get; set; }
        public AdoptionStatus AdoptionStatus { get; set; }
        public Guid InstitutionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Institution Institution { get; set; } = null!;

        public ICollection<AnimalPhoto> Photos { get; set; } = new List<AnimalPhoto>();
        public ICollection<AdoptionRequest> AdoptionRequest { get; set; } = new List<AdoptionRequest>();
        public ICollection<AnimalVaccine> AnimalVaccine { get; set; } = new List<AnimalVaccine>();
    }
}
