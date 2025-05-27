using Commention.Domain.Interfaces;
using MediatR;
using System.Security.Claims;

namespace Commention.Application.Commands.Comment.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, long>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ClaimsPrincipal _user;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, ClaimsPrincipal user)
        {
            _commentRepository = commentRepository;
            _user = user;
        }
        
        public async Task<long> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var model = new Domain.Models.Entities.Comment
            {
                Body = request.Body,
                UserId = long.Parse(_user.FindFirst(ClaimTypes.NameIdentifier)!.Value),
                CreateDate = DateTime.Now,
                IsConfirm = false,
                ReplayId = request.ReplayId
            };
            await _commentRepository.CreateCommentAsync(model);
            return model.Id;
        }
    }
}
