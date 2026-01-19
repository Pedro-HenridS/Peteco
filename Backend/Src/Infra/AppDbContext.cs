using Domain.Entities.AdoptionRequest;
using Domain.Entities.Address;
using Domain.Entities.AnimalPhoto;
using Domain.Entities.Animals;
using Domain.Entities.AnimalVaccine;
using Domain.Entities.Institution;
using Domain.Entities.InstitutionUser;
using Domain.Entities.User;
using Domain.Entities.Vaccine;
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
        public DbSet<Adress> Adress { get; set; }
    }
}
