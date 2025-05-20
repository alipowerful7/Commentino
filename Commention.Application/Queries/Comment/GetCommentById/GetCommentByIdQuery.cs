using MediatR;

namespace Commention.Application.Queries.Comment.GetCommentById
{
    public class GetCommentByIdQuery : IRequest<GetCommentByIdDto>
    {
        public long Id { get; set; }
    }
}
