using System.Text.RegularExpressions;

namespace LoginForm.BL.Validators
{
    public static class LoginValidator
    {
        public static bool IsValid(string login)
        {
            var regex = new Regex("^[a-zA-Z0-9\\\\_]+$");

            return regex.IsMatch(login);
        }
    }
}
