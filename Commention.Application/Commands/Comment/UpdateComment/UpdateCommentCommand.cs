using MediatR;

namespace Commention.Application.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string? Body { get; set; }
    }
}
