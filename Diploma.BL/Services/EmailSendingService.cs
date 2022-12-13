using Diploma.BL.Services.Contracts;
using System.Net.Mail;
using System.Net;
using Diploma.BL.Options;
using Microsoft.Extensions.Options;
using System.Web;

namespace Diploma.BL.Services
{
    public class EmailSendingService : IEmailSendingService
    {
        private readonly SmtpConfigOptions _smtpConfig;

        public EmailSendingService(IOptions<SmtpConfigOptions> options)
        {
            _smtpConfig = options.Value;
        }

        public async Task SendResetPasswordEmailAsync(string toEmail)
        {
            var encodedEmail = HttpUtility.UrlEncode(toEmail);

            var redirectUrl = $@"https://localhost:4200/change-password?email={encodedEmail}";
            var message = ConstructEmailMessage($"<h1>Reset Your Password</h1><a href=\"{redirectUrl}\">Click Here</a>", toEmail);

            await Send(message);
        }

        private MailMessage ConstructEmailMessage(string content, string toEmail)
        {
            var message = new MailMessage();
            message.To.Add(toEmail);

            message.From = new MailAddress(_smtpConfig.Email,
                                       _smtpConfig.Name,
                                       System.Text.Encoding.UTF8);

            message.IsBodyHtml = true;
            message.Body = content;
            message.Subject = "Reset Your password";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            return message;
        }

        private async Task Send(MailMessage message)
        {
            var client = new SmtpClient();

            client.UseDefaultCredentials = false;

            client.Credentials = new NetworkCredential(
                                  _smtpConfig.Email,
                                  _smtpConfig.Password);

            client.Host = _smtpConfig.Host;
            client.Port = _smtpConfig.Port;

            client.EnableSsl = true;

            try
            {
                await client.SendMailAsync(message);
            }
            catch (Exception e)
            {
                //add logging here
                throw;
            }
            finally
            {
                client?.Dispose();
            }
        }
    }
}
