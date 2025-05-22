using Commention.Application.Interfaces;
using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Queries.User.SendEmailToAll
{
    public class SendEmailToAllQueryHandler : IRequestHandler<SendEmailToAllQuery>
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;

        public SendEmailToAllQueryHandler(IEmailService emailService, IUserRepository userRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
        }

        public async Task Handle(SendEmailToAllQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersAsync();
            foreach (var user in users)
            {
                _ = _emailService.SendEmailAsync(user.Email!, request.Subject!, request.Body!);
            }
        }
    }
}
