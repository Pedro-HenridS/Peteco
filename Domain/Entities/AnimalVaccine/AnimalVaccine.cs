namespace Domain.Entities
{
    public class AnimalVaccine
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public Guid VaccineId { get; set; }
        public DateTime VaccinedAt { get; set; }
        public int DoseReceived { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Dog Dog { get; set; } = null!;
        public Vaccine Vaccine { get; set; } = null!;
    }
}
