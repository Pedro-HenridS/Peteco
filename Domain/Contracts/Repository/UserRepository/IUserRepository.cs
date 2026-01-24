using Domain.Dtos.Requests.CreateUser;

namespace Domain.Contracts.Repository.UserRepository
{
    public interface IUserRepository
    {
        public Task<bool> EmailAlreadyExist(string email);
        public Task CreateUser(CreateUserRequest user);
    }
}
