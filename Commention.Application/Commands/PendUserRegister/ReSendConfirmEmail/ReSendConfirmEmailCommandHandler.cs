using Commention.Application.Interfaces;
using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Commands.PendUserRegister.ReSendConfirmEmail
{
    public class ReSendConfirmEmailCommandHandler : IRequestHandler<ReSendConfirmEmailCommand, long>
    {
        private readonly IPendUserRegisterRepository _pendUserRegisterRepository;
        private readonly IEmailService _emailService;
        public ReSendConfirmEmailCommandHandler(IPendUserRegisterRepository pendUserRegisterRepository, IEmailService emailService)
        {
            _pendUserRegisterRepository = pendUserRegisterRepository;
            _emailService = emailService;
        }

        public async Task<long> Handle(ReSendConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var model = await _pendUserRegisterRepository.GetPendUserRegisterByIdAsync(request.Id);
            model.ExpireDate = DateTime.Now.AddMinutes(15);
            model.ConfirmCode = new Random().Next(1000, 9999).ToString();
            model.UpdateDate = DateTime.Now;
            await _pendUserRegisterRepository.UpdatePendUserRegisterAsync(model);
            await _emailService.SendConfirmationEmailAsync(model.Email!, model.ConfirmCode);
            return model.Id;
        }
    }
}
