using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class AnimalPhotoMap : IEntityTypeConfiguration<AnimalPhoto>
    {
        public void Configure(EntityTypeBuilder<AnimalPhoto> builder)
        {
            builder.ToTable("AnimalPhoto");

            builder.HasKey(ap => ap.Id);

            builder.HasOne(ap => ap.Dog)
                .WithMany(d => d.Photos)
                .HasForeignKey(ap => ap.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ap => ap.PhotoUrl)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(ap => ap.IsMain);

            builder.Property(ap => ap.CreatedAt)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(ap => ap.UpdatedAt)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}