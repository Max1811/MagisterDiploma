namespace Diploma.API.Models
{
    public class ChangePasswordDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }
    }
}
