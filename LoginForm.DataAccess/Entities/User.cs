﻿namespace LoginForm.DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public string HashedPassword { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
