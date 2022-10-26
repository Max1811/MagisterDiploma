﻿using AutoMapper;
using LoginForm.BL.Models;
using LoginForm.BL.Services.Contracts;
using LoginForm.DataAccess.Entities;
using LoginForm.DataAccess.Repositories.Contracts;
using LoginForm.Shared;

namespace LoginForm.BL.Services
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

        public async Task<User> SignUp(SignUpModel model)
        {
            byte[] passwordSalt;
            var hashedPassword = Encryptor.EncryptWithRandomSalt(model.Password, out passwordSalt);

            var user = _mapper.Map<User>(model);
            user.HashedPassword = hashedPassword;
            user.PasswordSalt = passwordSalt;

            //add check for existing user by login
            return await _userRepository.Add(user);
        }

        public async Task<User?> ValidateUser(string login, string password)
        {
            var user = await _userRepository.GetByLogin(login);

            return user is not null && user.HashedPassword == Encryptor.Encrypt(password, user.PasswordSalt) ? user : null;
        }
    }
}
