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

        public Task<Guid> CreateAddressReturnId(AddressRequest addressRequest)
        {
            var entity = new Address()
            {
                Id = Guid.NewGuid(),
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
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding address entity to the database context", ex);
            }


            return _db.SaveChangesAsync().ContinueWith(task => entity.Id);
        }

        public async Task SetForeignId(Guid foreignId, Guid addressId, int type)
        {
            if (type == 1)
            {
                try
                {
                    _db.Adress.Find(addressId).UserId = foreignId;
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error setting UserId foreign key", ex);
                }

                return;
            }

            if (type == 2)
            {
                try
                {
                    _db.Adress.Find(addressId).InstitutionId = foreignId;
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error setting InstitutionId foreign key", ex);
                }

                return;
            }
        }
    }
}
