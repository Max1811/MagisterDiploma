using AutoMapper;
using Diploma.BL.Models;
using Diploma.BL.Services.Contracts;
using Diploma.BL.Validators;
using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;
using Diploma.Shared;
using Diploma.Shared.Enums;

namespace Diploma.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<SignUpResponse> SignUp(SignUpModel model)
        {
            var response = ValidateSignUpModel(model);

            if (response != SignUpResponse.Success)
                return response;

            bool isUserExists = await _userRepository.IsUserExists(model.Login);

            if (isUserExists)
                response = SignUpResponse.LoginIsTaken;
            else
            {
                byte[] passwordSalt;
                var hashedPassword = Encryptor.EncryptWithRandomSalt(model.Password, out passwordSalt);

                var user = _mapper.Map<User>(model);
                user.HashedPassword = hashedPassword;
                user.PasswordSalt = passwordSalt;

                await _userRepository.Add(user);
            }
            
            return response;
        }

        public async Task<(User?, LoginResponse)> ValidateUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return (null, LoginResponse.EmptyData);

            var user = await _userRepository.GetByLogin(login);

            if (user == null)
                return (null, LoginResponse.IncorrectLogin);

            else if (user.HashedPassword != Encryptor.Encrypt(password, user.PasswordSalt))
                return (null, LoginResponse.IncorrectPassword);

            return (user, LoginResponse.Success);
        }

        private SignUpResponse ValidateSignUpModel(SignUpModel model)
        {
            if (string.IsNullOrEmpty(model.Login) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.Email))
                return SignUpResponse.EmptyFields;

            if (!EmailValidator.IsValid(model.Email))
                return SignUpResponse.InvalidEmail;

            if (!LoginValidator.IsValid(model.Login))
                return SignUpResponse.InvalidLogin;

            if (!PasswordValidator.IsValid(model.Password))
                return SignUpResponse.InvalidPassword;

            return SignUpResponse.Success;
        }
    }
}
