using Domain.Contracts.Repository.UserRepository;
using Domain.Dtos.Requests.CreateUser;
using Infra;

namespace Application.Services.User
{
    public class UserService : IUserRepository
    {

        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
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

        public Task CreateUser(CreateUserRequest user)
        {
            try
            {
                Domain.Entities.User dbUser = new()
                {
                    Id = new Guid(),
                    Username = user.Username,
                    Email = user.Email,
                    PasswordHash = user.Password,
                    Phone = user.Phone,
                    FullName = user.FullName,
                    Address = user,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,

                };

                _db.Users.Add(user);

            }
            catch (Exception)
            {
                Console.WriteLine("Error creating user.");
            }


            throw new NotImplementedException();
        }
    }
}
