using Commention.Domain.Interfaces;
using Commention.Domain.Models.Enums;
using MediatR;

namespace Commention.Application.Commands.PendUserRegister.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand>
    {
        private readonly IPendUserRegisterRepository _pendUserRegisterRepository;
        private readonly IUserRepository _userRepository;

        public ConfirmEmailCommandHandler(IPendUserRegisterRepository pendUserRegisterRepository, IUserRepository userRepository)
        {
            _pendUserRegisterRepository = pendUserRegisterRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var pendUserRegister = await _pendUserRegisterRepository.GetPendUserRegisterByIdAsync(request.Id);
            if (pendUserRegister.ConfirmCode == request.ConfirmCode && pendUserRegister.ExpireDate <= DateTime.Now)
            {
                var model = new Domain.Models.Entities.User
                {
                    FirstName = pendUserRegister.FirstName,
                    LastName = pendUserRegister.LastName,
                    Email = pendUserRegister.Email,
                    CreateDate = DateTime.Now,
                    UserName = pendUserRegister.UserName,
                    UserRole = UserRole.User,
                    Password = pendUserRegister.Password
                };
                await _userRepository.CreateUserAsync(model);
                await _pendUserRegisterRepository.DeletePendUserRegisterAsync(pendUserRegister.Id);
            }
            else
            {
                throw new Exception("کد تایید اشتباه است یا 15 دقیقه از ارسال کد گذشته است.");
            }
        }
    }
}
