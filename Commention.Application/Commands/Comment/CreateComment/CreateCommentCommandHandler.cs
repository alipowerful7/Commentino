using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Commands.Comment.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, long>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<long> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.Models.Entities.Comment
            {
                Body = request.Body,
                UserId = request.UserId,
                CreateDate = DateTime.Now,
                IsConfirm = false,
                ReplayId = request.ReplayId
            };
            await _commentRepository.CreateCommentAsync(model);
            return model.Id;
        }
    }
}
