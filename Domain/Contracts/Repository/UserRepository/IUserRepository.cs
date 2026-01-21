using Domain.Entities;

namespace Domain.Contracts.Repository.UserRepository
{
    public interface IUserRepository
    {
        public Task<bool> EmailAlreadyExist(string email);
        public Task CreateUser(User user);
    }
}
