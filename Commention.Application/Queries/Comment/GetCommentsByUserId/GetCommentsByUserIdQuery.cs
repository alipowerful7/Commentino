using MediatR;

namespace Commention.Application.Queries.Comment.GetCommentsByUserId
{
    public class GetCommentsByUserIdQuery : IRequest<IEnumerable<GetCommentsByUserIdDto>>
    {
        public long UserId { get; set; }
        public GetCommentsByUserIdQuery(long userId)
        {
            UserId = userId;
        }
        public GetCommentsByUserIdQuery()
        {
            UserId = -1;
        }
    }
}
