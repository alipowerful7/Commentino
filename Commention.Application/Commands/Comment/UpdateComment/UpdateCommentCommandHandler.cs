using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, long>
    {
        private readonly ICommentRepository _commentRepository;

        public UpdateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<long> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var model = await _commentRepository.GetCommentByIdAsync(request.Id);
            model.UpdateDate = DateTime.Now;
            model.Body = request.Body;
            await _commentRepository.UpdateCommentAsync(model);
            return model.Id;
        }
    }
}
