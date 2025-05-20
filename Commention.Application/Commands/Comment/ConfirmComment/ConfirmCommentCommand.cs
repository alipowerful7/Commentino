using MediatR;

namespace Commention.Application.Commands.Comment.ConfirmComment
{
    public class ConfirmCommentCommand : IRequest<long>
    {
        public long Id { get; set; }
    }
}
