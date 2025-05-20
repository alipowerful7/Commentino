using MediatR;

namespace Commention.Application.Commands.PendUserRegister.ReSendConfirmEmail
{
    public class ReSendConfirmEmailCommand : IRequest<long>
    {
        public long Id { get; set; }
    }
}
