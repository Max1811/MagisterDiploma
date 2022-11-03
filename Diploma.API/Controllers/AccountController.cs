using AutoMapper;
using Diploma.API.Models;
using Diploma.BL.Models;
using Diploma.BL.Services.Contracts;
using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;
using Diploma.Shared.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Diploma.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserAware _currentUserAware;
        private readonly IMapper _mapper;

        public AccountController(
            IUserService userService,
            IUserRepository userRepository,
            ICurrentUserAware currentUserAware,
            IMapper mapper)
        {
            _userService = userService;
            _userRepository = userRepository;
            _currentUserAware = currentUserAware;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<LoginResponse> Login(LoginCredentials credentials)
        {
            var (user, response) = await _userService.ValidateUser(credentials.Login, credentials.Password);

            if (user != null)
            {
                var claims = new[] {
                    new Claim(ClaimTypes.Name, user.Login)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
            }

            return response;
        }

        [HttpPost("sign-up")]
        public async Task<SignUpResponse> SignUp(SignUpDto credentials)
        {
            var userModel = _mapper.Map<SignUpModel>(credentials);

            var response = await _userService.SignUp(userModel);

            return response;
        }

        [HttpPost("logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        [HttpGet("me")]
        public async Task<CurrentUserDto?> Me()
        {
            User? currentUser = await _currentUserAware.GetCurrentUser();

            return currentUser == null ? null : 
                await Task.FromResult(new CurrentUserDto
                {
                    Id = currentUser.Id,
                    Login = currentUser.Login
                });
        }

        [HttpPost("password-recovery")]
        public async Task RecoverPassword(string email)
        {

        }
    }
}
