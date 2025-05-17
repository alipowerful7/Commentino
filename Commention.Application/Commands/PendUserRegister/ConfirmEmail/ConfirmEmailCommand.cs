using MediatR;

namespace Commention.Application.Commands.PendUserRegister.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest
    {
        public long Id { get; set; }
        public string? ConfirmCode { get; set; }
    }
}
