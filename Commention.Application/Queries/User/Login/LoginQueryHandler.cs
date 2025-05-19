using Commention.Application.Interfaces;
using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Queries.User.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginQueryHandler(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUserNameAndPassword(request.UserName!, request.Password!);
            return new LoginDto
            {
                Token = _jwtService.GenerateToken(user)
            };
        }
    }
}
