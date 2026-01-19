using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Vaccine
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public int TotalDoses { get; set; }
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        public ICollection<AnimalVaccine> AnimalVaccines { get; set; } = new List<AnimalVaccine>();
    }
}
