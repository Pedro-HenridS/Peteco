using Domain.Entities.Animals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class DogMap : IEntityTypeConfiguration<Dog>
    {

        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.ToTable("Dogs");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Age)
                .HasMaxLength(3);

            builder.Property(d => d.Size)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(d => d.Breed)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Color)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Description)
                .HasMaxLength(200);

            builder.Property(d => d.HealthStatus)
                .HasConversion<int>();

            builder.Property(d => d.IsNeutered)
                .IsRequired();

            builder.Property(d => d.AdoptionStatus)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(d => d.Institution)
                .WithMany(o => o.Dogs)
                .HasForeignKey(d => d.InstitutionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.CreatedAt)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(d => d.UpdatedAt)
                .IsRequired()
                .HasColumnType("date");

            builder.HasMany(d => d.Photos)
                .WithOne(d => d.Dog)
                .HasForeignKey(d => d.Dog);

            builder.HasIndex(d => d.Name);
        }
    }
}
