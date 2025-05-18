using Commention.Domain.Models.Enums;
using MediatR;

namespace Commention.Application.Commands.User.CreateUser
{
    public class CreateUserCommand : IRequest<long>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public UserRole UserRole { get; set; }
    }
}
