using Diploma.DataAccess.Entities;

namespace Diploma.DataAccess.Repositories.Contracts
{
    public interface IUserRepository
    {
        public Task<User?> GetByLoginAsync(string login);

        public Task<User?> GetByEmailAsync(string email);

        public Task UpdateAsync(User user);

        public Task<User> AddAsync(User entity);

        public Task<bool> IsUserExists(string login);

        public Task ChangePasswordAsync(string email, string hashedPassword, byte[] passwordSalt);
    }
}
