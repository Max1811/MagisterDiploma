using Diploma.DataAccess.Entities;

namespace Diploma.BL.Services.Contracts
{
    public interface ICurrentUserAware
    {
        Task<User?> GetCurrentUser();
    }
}
