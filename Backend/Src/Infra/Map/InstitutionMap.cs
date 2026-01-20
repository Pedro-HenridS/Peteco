

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class InstitutionMap : IEntityTypeConfiguration<Institution>
    {

        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.ToTable("Institutions");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(i => i.Phone)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(i => i.Cnpj)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(i => i.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.IsVerified)
                .IsRequired();

            builder.Property(i => i.WebSite)
                .HasMaxLength(200);

            builder.HasMany(i => i.Address)
                .WithOne(i => i.Institution)
                .HasForeignKey(i => i.InstitutionId);

            builder.HasMany(i => i.Dogs)
                .WithOne(i => i.Institution)
                .HasForeignKey(i => i.InstitutionId);

            builder.HasMany(i => i.InstitutionUser)
                .WithOne(i => i.Institution)
                .HasForeignKey(i => i.InstitutionId);

            builder.Property(d => d.CreatedAt)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(d => d.UpdatedAt)
                .IsRequired()
                .HasColumnType("date");
        }

    }
}
