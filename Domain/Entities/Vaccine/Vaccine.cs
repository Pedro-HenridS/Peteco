using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Vaccine
    {
        public Guid Id { get; set; }
        [MaxLength(100)]

        public Guid AnimalVaccinesId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public int DosesRequired { get; set; }
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        public ICollection<AnimalVaccine> AnimalVaccines { get; set; } = new List<AnimalVaccine>();
    }
}
