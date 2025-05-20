using MediatR;

namespace Commention.Application.Queries.Comment.GetAllComments
{
    public class GetAllCommentsQuery : IRequest<IEnumerable<GetAllCommentsDto>>
    {
    }
}
