
using Domain.Contracts.Repository.UserRepository;
using Domain.Dtos.Requests.CreateUser;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;


        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public Task<bool> EmailAlreadyExist(string email)
        {

            bool fetch;

            try
            {
                fetch = _db.Users.Any(u => u.Email == email);
            }
            catch (Exception)
            {
                Console.WriteLine("Error fetching user by email.");
                fetch = false;
            }

            return Task.FromResult(fetch);

            throw new NotImplementedException();
        }

        public async Task<Guid> CreateUser(CreateUserRequest user)
        {
            try
            {
                User dbUser = new()
                {
                    Id = new Guid(),
                    Username = user.Username,
                    Email = user.Email,
                    PasswordHash = user.Password,
                    Phone = user.Phone,
                    FullName = user.FullName,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _db.Users.Add(dbUser);
                await _db.SaveChangesAsync();

                return dbUser.Id;
            }
            catch (Exception)
            {
                Console.WriteLine("Error creating user.");
            }

            throw new NotImplementedException();
        }

        public async Task<Guid?> GetIdByEmail(string email)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user != null)
                {
                    return user.Id;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error verifying email.");
                throw new NotImplementedException();
            }

            return null;
        }
        public async Task<string?> GetPasswordByEmail(string email)
        {
            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (user != null)
                {
                    return user.PasswordHash;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error verifying password.");
                throw new NotImplementedException();
            }

            return null;
        }
        public async Task<User> GetUser(Guid userId)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == userId) ?? new User();
        }
    }
}
