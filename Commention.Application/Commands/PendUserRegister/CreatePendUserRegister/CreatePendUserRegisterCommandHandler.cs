using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Commands.PendUserRegister.CreatePendUserRegister
{
    public class CreatePendUserRegisterCommandHandler : IRequestHandler<CreatePendUserRegisterCommand, long>
    {
        private readonly IPendUserRegisterRepository _pendUserRegisterRepository;

        public CreatePendUserRegisterCommandHandler(IPendUserRegisterRepository pendUserRegisterRepository)
        {
            _pendUserRegisterRepository = pendUserRegisterRepository;
        }

        public async Task<long> Handle(CreatePendUserRegisterCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.Models.Entities.PendUserRegister
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                CreateDate = DateTime.Now,
                Email = request.Email,
                UserName = request.UserName,
                ExpireDate = DateTime.Now.AddMinutes(15),
                ConfirmCode = new Random().Next(100000, 999999).ToString()
            };
            await _pendUserRegisterRepository.CreatePendUserRegisterAsync(model);
            return model.Id;
        }
    }
}
