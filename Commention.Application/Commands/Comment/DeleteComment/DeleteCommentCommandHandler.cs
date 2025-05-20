using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, long>
    {
        private readonly ICommentRepository _commentRepository;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<long> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            await _commentRepository.DeleteCommentAsync(request.Id);
            return request.Id;
        }
    }
}
