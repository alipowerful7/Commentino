using MediatR;

namespace Commention.Application.Commands.PendUserRegister.DeletePendUserRegister
{
    public class DeletePendUserRegisterCommand : IRequest<long>
    {
        public long Id { get; set; }
    }
}
