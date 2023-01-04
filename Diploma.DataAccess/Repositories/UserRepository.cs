using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Diploma.DataAccess.Repositories
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        private DataContext _dataContext;

        public UserRepository(DataContext dataContext)
            :base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task ChangePasswordAsync(string email, string hashedPassword, byte[] passwordSalt)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            user.HashedPassword = hashedPassword;
            user.PasswordSalt = passwordSalt;

            await UpdateAsync(user);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task<User?> GetByLoginAsync(string login)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Login == login);

            return user;
        }

        public async Task<bool> IsUserExists(string login)
        {
            return await _dataContext.Users.AnyAsync(u => u.Login == login);
        }
    }
}
