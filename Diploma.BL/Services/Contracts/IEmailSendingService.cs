namespace Diploma.BL.Services.Contracts
{
    public interface IEmailSendingService
    {
        public Task SendResetPasswordEmailAsync(string toEmail);
    }
}
