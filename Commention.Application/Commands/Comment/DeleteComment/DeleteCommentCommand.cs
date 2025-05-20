using MediatR;

namespace Commention.Application.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommand : IRequest<long>
    {
        public long Id { get; set; }
    }
}
