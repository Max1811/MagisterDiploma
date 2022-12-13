using Diploma.BL.Services.Contracts;
using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Diploma.BL.Services
{
    public class CurrentUserAware : ICurrentUserAware
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public CurrentUserAware(
            IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<User?> GetCurrentUser()
        {
            ClaimsPrincipal? user = _httpContextAccessor.HttpContext?.User;

            if (user != null)
            {
                string? userLogin = user.FindFirst(ClaimTypes.Name)?.Value;

                if (userLogin != null)
                {
                    return await _userRepository.GetByLoginAsync(userLogin);
                }
            }

            return null;
        }
    }
}
