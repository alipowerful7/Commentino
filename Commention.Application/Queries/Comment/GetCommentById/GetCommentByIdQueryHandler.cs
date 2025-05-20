using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Queries.Comment.GetCommentById
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdDto>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentByIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GetCommentByIdDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(request.Id);
            return new GetCommentByIdDto
            {
                Body = comment.Body,
                IsConfirm = comment.IsConfirm,
                UserName = comment.User?.UserName
            };
        }
    }
}
