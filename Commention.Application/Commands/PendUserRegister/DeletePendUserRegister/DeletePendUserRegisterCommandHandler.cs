using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Commands.PendUserRegister.DeletePendUserRegister
{
    public class DeletePendUserRegisterCommandHandler : IRequestHandler<DeletePendUserRegisterCommand, long>
    {
        private readonly IPendUserRegisterRepository _pendUserRegisterRepository;

        public DeletePendUserRegisterCommandHandler(IPendUserRegisterRepository pendUserRegisterRepository)
        {
            _pendUserRegisterRepository = pendUserRegisterRepository;
        }

        public async Task<long> Handle(DeletePendUserRegisterCommand request, CancellationToken cancellationToken)
        {
            await _pendUserRegisterRepository.DeletePendUserRegisterAsync(request.Id);
            return request.Id;
        }
    }
}
