using Domain.Entities;
using Domain.Entities.Animals;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequest { get; set; }
        public DbSet<AnimalPhoto> AnimalPhoto { get; set; }
        public DbSet<Dog> Dog { get; set; }
        public DbSet<AnimalVaccine> AnimalVaccine { get; set; }
        public DbSet<InstitutionUser> InstitutionUser { get; set; }
        public DbSet<Vaccine> Vaccine { get; set; }
        public DbSet<Institution> Institution { get; set; }
        public DbSet<Address> Adress { get; set; }
    }
}
