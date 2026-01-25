using Domain.Contracts.Services;
using Domain.Dtos.Requests.CreateUser;

namespace Application.UseCases.CreateUser
{
    public class CreateUserUseCase
    {

        private IUserService _userService;
        private IPasswordHasher _passwordHasher;

        public CreateUserUseCase(
            IUserService userService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task Execute(CreateUserRequest request)
        {
            try
            {
                if (await _userService.EmailAlreadyExist(request.Email))
                    return;

                request.Password = _passwordHasher.Hash(request.Password);

                await _userService.CreateUser(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
