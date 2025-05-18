using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.Models.Entities.User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreateDate = DateTime.Now,
                UserRole = request.UserRole
            };
            await _userRepository.CreateUserAsync(model);
            return model.Id;
        }
    }
}
