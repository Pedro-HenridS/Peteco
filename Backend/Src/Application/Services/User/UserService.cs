using Domain.Contracts.Repository.AddressRepository;
using Domain.Contracts.Repository.UserRepository;
using Domain.Contracts.Services;
using Domain.Dtos.Requests.CreateUser;
using FluentValidation;

namespace Application.Services.User
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IValidator<CreateUserRequest> _validator;

        public UserService(
            IUserRepository userRepository,
            IAddressRepository addressRepository,
            IValidator<CreateUserRequest> validator)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _validator = validator;
        }

        public async Task CreateUserRotine(CreateUserRequest request)
        {
            var result = await _validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationException("[Validation failed] | ", result.Errors);
            }

            Guid addressId = await _addressRepository.CreateAddressReturnId(request.Address);

            request.Address.Id = addressId;

            await _userRepository.CreateUser(request);


        }
    }
}
