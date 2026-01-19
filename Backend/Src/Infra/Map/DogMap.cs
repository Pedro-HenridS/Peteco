using Domain.Entities.Animals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Map
{
    public class DogMap : IEntityTypeConfiguration<Dog>
    {

        public void Configure(EntityTypeBuilder<Dog> builder)
        {

        }
    }
}
