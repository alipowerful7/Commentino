namespace Commention.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendConfirmationEmailAsync(string email, string confirmationCode);
    }
}
