using Commention.Domain.Interfaces;
using MediatR;
using System.Security.Claims;

namespace Commention.Application.Queries.Comment.GetCommentsByUserId
{
    public class GetCommentsByUserIdQueryHandler : IRequestHandler<GetCommentsByUserIdQuery, IEnumerable<GetCommentsByUserIdDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ClaimsPrincipal _user;

        public GetCommentsByUserIdQueryHandler(ICommentRepository commentRepository, ClaimsPrincipal user)
        {
            _commentRepository = commentRepository;
            _user = user;
        }

        public async Task<IEnumerable<GetCommentsByUserIdDto>> Handle(GetCommentsByUserIdQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Commention.Domain.Models.Entities.Comment> comments;
            if (request.UserId != -1)
            {
                comments = await _commentRepository.GetCommentsByUserIdAsync(request.UserId);
            }
            else
            {
                comments = await _commentRepository.GetCommentsByUserIdAsync(long.Parse(_user.FindFirst(ClaimTypes.NameIdentifier)!.Value));
            }
            return comments.Select(comment => new GetCommentsByUserIdDto
            {
                Id = comment.Id,
                Body = comment.Body,
                IsConfirm = comment.IsConfirm
            }).ToList();
        }
    }
}
