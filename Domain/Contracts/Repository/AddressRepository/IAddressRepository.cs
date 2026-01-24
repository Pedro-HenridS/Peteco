using Domain.Dtos.Requests.Address;

namespace Domain.Contracts.Repository.AddressRepository
{
    public interface IAddressRepository
    {
        public Task<Guid> CreateAddressReturnId(AddressRequest addressRequest);
    }
}
