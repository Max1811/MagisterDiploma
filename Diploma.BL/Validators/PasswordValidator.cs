using System.Text.RegularExpressions;

namespace Diploma.BL.Validators
{
    public static class PasswordValidator
    {
        public static bool IsValid(string password)
        {
            //implement password regex
            var regex = new Regex("");

            return regex.IsMatch(password);
        }
    }
}
