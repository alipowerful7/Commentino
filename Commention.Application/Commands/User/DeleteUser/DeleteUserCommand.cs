using MediatR;

namespace Commention.Application.Commands.User.DeleteUser
{
    public class DeleteUserCommand : IRequest<long>
    {
        public long Id { get; set; }
    }
}
