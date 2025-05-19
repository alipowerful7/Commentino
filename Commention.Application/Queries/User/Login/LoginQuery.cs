using MediatR;

namespace Commention.Application.Queries.User.Login
{
    public class LoginQuery : IRequest<LoginDto>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
