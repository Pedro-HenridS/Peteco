using Domain.Dtos.Requests.CreateUser;
using Domain.Entities;

namespace Domain.Contracts.Repository.UserRepository
{
    public interface IUserRepository
    {
        public Task<bool> EmailAlreadyExist(string email);
        public Task<Guid> CreateUser(CreateUserRequest user);
        public Task<Guid?> GetIdByEmail(string email);
        public Task<string?> GetPasswordByEmail(string email);
        public Task<User> GetUser(Guid userId);
    }
}
