namespace Domain.Entities
{
    public class AnimalPhoto
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
        public bool IsMain { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Dog Dog { get; set; } = null!;
    }
}
