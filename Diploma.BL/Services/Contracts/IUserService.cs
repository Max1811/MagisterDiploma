using Diploma.DataAccess.Entities;
using Diploma.BL.Models;
using Diploma.Shared.Enums;

namespace Diploma.BL.Services.Contracts
{
    public interface IUserService
    {
        public Task<(User?, LoginResponse)> ValidateUser(string login, string password);

        public Task<SignUpResponse> SignUp(SignUpModel model);
    }
}
