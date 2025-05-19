using MediatR;

namespace Commention.Application.Queries.User.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<GetAllUsersDto>>
    {
    }
}
