using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Commands.Comment.ConfirmComment
{
    public class ConfirmCommentCommandHandler : IRequestHandler<ConfirmCommentCommand, long>
    {
        private readonly ICommentRepository _commentRepository;

        public ConfirmCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<long> Handle(ConfirmCommentCommand request, CancellationToken cancellationToken)
        {
            await _commentRepository.ConfirmComment(request.Id);
            return request.Id;
        }
    }
}
