namespace Commention.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendConfirmationEmailAsync(string email, string confirmationCode);
        Task SendEmailAsync(string email, string subject, string body);
    }
}
