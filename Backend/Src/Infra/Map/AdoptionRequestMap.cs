

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class AdoptionRequestMap : IEntityTypeConfiguration<AdoptionRequest>
    {
        public void Configure(EntityTypeBuilder<AdoptionRequest> builder)
        {
            builder.ToTable("AdoptionRequests");

            builder.HasKey(ar => ar.Id);

            builder.HasOne(ar => ar.Animal)
                .WithMany(ar => ar.AdoptionRequest)
                .HasForeignKey(ar => ar.AnimalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ar => ar.User)
                .WithMany(u => u.AdoptionRequest)
                .HasForeignKey(ar => ar.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ar => ar.Status)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(ar => ar.InstitutionUser)
                .WithOne(u => u.AdoptionRequest)
                .HasForeignKey<AdoptionRequest>(ar => ar.ReviewedByInstitutionUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ar => ar.ReviewedAt)
                .HasColumnType("date");

            builder.Property(ar => ar.CreatedAt)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(ar => ar.UpdatedAt)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}
