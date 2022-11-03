using LoginForm.BL.Models;
using LoginForm.DataAccess.Entities;
using LoginForm.Shared.Enums;

namespace LoginForm.BL.Services.Contracts
{
    public interface IUserService
    {
        public Task<(User?, LoginResponse)> ValidateUser(string login, string password);

        public Task<SignUpResponse> SignUp(SignUpModel model);
    }
}
