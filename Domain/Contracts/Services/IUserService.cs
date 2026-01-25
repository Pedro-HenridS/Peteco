using Domain.Dtos.Requests.CreateUser;
using Domain.Dtos.Requests.Login;

namespace Domain.Contracts.Services
{
    public interface IUserService
    {
        public Task CreateUser(CreateUserRequest request);
        public Task<Guid?> VerifyLogin(LoginRequest request);
        public Task<JwtTokenRequest> GetUserClaims(Guid? userId);
        public Task<bool> EmailAlreadyExist(string email);
    }
}
