using MediatR;

namespace Commention.Application.Queries.User.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdDto>
    {
        public long Id { get; set; }
    }
}
