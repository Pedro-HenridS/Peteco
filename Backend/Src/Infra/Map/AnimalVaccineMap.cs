using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class AnimalVaccineMap : IEntityTypeConfiguration<AnimalVaccine>
    {
        public void Configure(EntityTypeBuilder<AnimalVaccine> builder)
        {
            builder.ToTable("AnimalVaccine");

            builder.HasKey(av => av.Id);

            builder.HasOne(av => av.Dog)
                .WithMany(d => d.AnimalVaccine)
                .HasForeignKey(av => av.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(av => av.Vaccine)
                .WithMany(v => v.AnimalVaccines)
                .HasForeignKey(av => av.VaccineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(av => av.VaccinedAt)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(av => av.CreatedAt)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(av => av.UpdatedAt)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}
