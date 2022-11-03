﻿using Diploma.DataAccess.Entities;

namespace Diploma.DataAccess.Repositories.Contracts
{
    public interface IUserRepository
    {
        public Task<User> GetByLogin(string login);

        public Task Update(User user);

        public Task<User> Add(User entity);

        public Task<bool> IsUserExists(string login);
    }
}