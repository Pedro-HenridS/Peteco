using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class VaccineMap : IEntityTypeConfiguration<Vaccine>
    {

        public void Configure(EntityTypeBuilder<Vaccine> builder)
        {
            builder.ToTable("Vaccines");

            builder.HasKey(v => v.Id);

            builder.HasMany(v => v.AnimalVaccines)
                .WithOne(av => av.Vaccine)
                .HasForeignKey(av => av.VaccineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.DosesRequired)
                .IsRequired();

            builder.Property(v => v.Description)
                .HasMaxLength(250);
        }
    }
}
