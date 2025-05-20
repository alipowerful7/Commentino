using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Queries.Comment.GetCommentsByUserId
{
    public class GetCommentsByUserIdQueryHandler : IRequestHandler<GetCommentsByUserIdQuery, IEnumerable<GetCommentsByUserIdDto>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentsByUserIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<GetCommentsByUserIdDto>> Handle(GetCommentsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetCommentsByUserIdAsync(request.UserId);
            return comments.Select(comment => new GetCommentsByUserIdDto
            {
                Body = comment.Body,
                IsConfirm = comment.IsConfirm
            }).ToList();
        }
    }
}
