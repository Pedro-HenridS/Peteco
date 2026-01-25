using Domain.Contracts.Repository.AddressRepository;
using Domain.Dtos.Requests.Address;
using Domain.Entities;

namespace Infra.Repository
{
    public class AddressRepository : IAddressRepository
    {

        private readonly AppDbContext _db;
        public AddressRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateAddress(AddressRequest addressRequest)
        {
            var entity = new Address()
            {
                Id = Guid.NewGuid(),
                InstitutionId = addressRequest.InstitutionId,
                UserId = addressRequest.UserId,
                City = addressRequest.City,
                Complement = addressRequest.Complement,
                Neighborhood = addressRequest.Neighborhood,
                State = addressRequest.State,
                Street = addressRequest.Street,
                ZipCode = addressRequest.ZipCode,
                Number = addressRequest.Number,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            try
            {
                _db.Adress.Add(entity);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding address entity to the database context", ex);
            }

            await Task.CompletedTask;
        }
    }
}
