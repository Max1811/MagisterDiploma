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
        private readonly IEmailSendingService _emailSendingService;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            IEmailSendingService emailSendingService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailSendingService = emailSendingService;
        }

        public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if(string.IsNullOrEmpty(changePasswordModel.Password) || string.IsNullOrEmpty(changePasswordModel.RepeatPassword))
            {
                return ChangePasswordResponse.EmptyFields;
            }

            else if (changePasswordModel.Password != changePasswordModel.RepeatPassword)
            {
                return ChangePasswordResponse.PasswordsNotMatch;
            }

            byte[] passwordSalt;
            var hashedPassword = Encryptor.EncryptWithRandomSalt(changePasswordModel.Password, out passwordSalt);

            await _userRepository.ChangePasswordAsync(changePasswordModel.Email, hashedPassword, passwordSalt);

            return ChangePasswordResponse.Success;
        }

        public async Task<PasswordRecoverResponse> RecoverPassword(string email)
        {
            if (!EmailValidator.IsValid(email))
                return PasswordRecoverResponse.EmailNotValid;

            var user = await _userRepository.GetByEmailAsync(email);

            if (user is null)
                return PasswordRecoverResponse.UserNotExists;

            try
            {
                await _emailSendingService.SendResetPasswordEmailAsync(email);
            }
            catch(Exception ex)
            {
                //log exception

                return PasswordRecoverResponse.EmailNotValid;
            }

            return PasswordRecoverResponse.Success;
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

                await _userRepository.AddAsync(user);
            }
            
            return response;
        }

        public async Task<(User?, LoginResponse)> ValidateUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                return (null, LoginResponse.EmptyData);

            var user = await _userRepository.GetByLoginAsync(login);

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
