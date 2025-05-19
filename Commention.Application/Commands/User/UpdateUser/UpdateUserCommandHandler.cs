using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Commands.User.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, long>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<long> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var model = await _userRepository.GetUserByIdAsync(request.UserId);
            model.FirstName = request.FirstName;
            model.LastName = request.LastName;
            await _userRepository.UpdateUserAsync(model);
            return model.Id;
        }
    }
}
