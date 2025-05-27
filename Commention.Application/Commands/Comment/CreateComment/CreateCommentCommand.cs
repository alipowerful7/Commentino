using MediatR;

namespace Commention.Application.Commands.Comment.CreateComment
{
    public class CreateCommentCommand : IRequest<long>
    {
        public string? Body { get; set; }
        public long? ReplayId { get; set; }
    }
}
