using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Commands.User.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, long>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<long> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUserAsync(request.Id);
            return request.Id;
        }
    }
}
