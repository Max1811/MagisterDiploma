﻿using System.ComponentModel.DataAnnotations;

namespace LoginForm.API.Models
{
    public class SignUpDto
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
