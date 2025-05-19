using Commention.Application.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Commention.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendConfirmationEmailAsync(string email, string confirmationCode)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");
            string smtpServer = emailSettings["SmtpServer"]!;
            int port = int.Parse(emailSettings["Port"]!);
            string senderEmail = emailSettings["SenderEmail"]!;
            string senderPassword = emailSettings["SenderPassword"]!;
            bool enableSSL = bool.Parse(emailSettings["EnableSSL"]!);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Commentino", senderEmail));

            string recipientEmail = email;
            message.To.Add(new MailboxAddress("", recipientEmail));

            message.Subject = "کد تایید حساب کاربری";
            message.Body = new TextPart("html")
            {
                Text = $"<h1>کد تایید شما:</h1><h3>{confirmationCode}</h3>"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpServer, port, SecureSocketOptions.StartTls);

                await client.AuthenticateAsync(senderEmail, senderPassword);

                await client.SendAsync(message);

                await client.DisconnectAsync(true);
            }
        }
    }
}
