using MediatR;

namespace Commention.Application.Commands.User.UpdateUser
{
    public class UpdateUserCommand : IRequest<long>
    {
        public long UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
