using Domain.Dtos.Requests.CreateUser;

namespace Domain.Contracts.Services
{
    public interface IUserService
    {
        public Task CreateUserRotine(CreateUserRequest request);
    }
}
