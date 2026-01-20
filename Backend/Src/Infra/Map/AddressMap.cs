using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Adresses");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Institution)
                .WithMany(i => i.Address)
                .HasForeignKey(a => a.InstitutionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.User)
                .WithOne(i => i.Address)
                .HasForeignKey<Address>("UserId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Number)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.Complement)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.ZipCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.CreatedAt)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(a => a.UpdatedAt)
                .IsRequired()
                .HasColumnType("date");
        }
    }
}
