namespace Diploma.BL.Options
{
    public class SmtpConfigOptions
    {
        public const string SMTP_CONFIG = "SmtpConfig";

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }
    }
}
