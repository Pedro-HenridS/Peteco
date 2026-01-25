using Domain.Contracts.Repository.AddressRepository;
using Domain.Contracts.Repository.UserRepository;
using Domain.Contracts.Services;
using Domain.Dtos.Requests.CreateUser;
using Domain.Dtos.Requests.Login;
using Domain.Enum.Role;
using FluentValidation;

namespace Application.Services.User
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IValidator<CreateUserRequest> _validator;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(
            IUserRepository userRepository,
            IAddressRepository addressRepository,
            IValidator<CreateUserRequest> validator,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _validator = validator;
            _passwordHasher = passwordHasher;
        }

        public async Task CreateUserRotine(CreateUserRequest request)
        {

            request.Password = _passwordHasher.Hash(request.Password);

            var user_id = await _userRepository.CreateUser(request);

            request.Address.UserId = user_id;

            await _addressRepository.CreateAddress(request.Address);
        }
        public async Task<Guid?> VerifyLogin(LoginRequest request)
        {

            var passwordHash = await _userRepository.GetPasswordByEmail(request.Email);

            if (string.IsNullOrEmpty(passwordHash))
                return null;

            var isValid = _passwordHasher.Verify(request.Password, passwordHash);

            if (isValid)
                return await _userRepository.GetIdByEmail(request.Email);

            return null;
        }
        public async Task<JwtTokenRequest> GetUserClaims(Guid? userId)
        {

            JwtTokenRequest claims = new();

            if (userId is null)
                return claims;

            try
            {
                var user = await _userRepository.GetUser((Guid)userId);

                List<string> roles = Enum.IsDefined(typeof(Role), user.Role) ? new List<string> { ((Role)user.Role).ToString() } : new List<string>();


                if (roles.Contains(string.Empty))
                    throw new Exception("User has an invalid role.");

                claims = new()
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Roles = roles
                };
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

            return await Task.FromResult(claims);
        }
    }
}
