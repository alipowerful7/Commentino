using Commention.Domain.Interfaces;
using MediatR;

namespace Commention.Application.Queries.Comment.GetAllComments
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<GetAllCommentsDto>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetAllCommentsQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<GetAllCommentsDto>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var allComments = await _commentRepository.GetAllCommentsAsync();
            var dict = allComments.Select(c => new GetAllCommentsDto
            {
                Id = c.Id,
                Body = c.Body,
                IsConfirm = c.IsConfirm,
                UserId = c.UserId,
                ReplayId = c.ReplayId,
                UserName = c.User?.UserName
            }).ToDictionary(dto => dto.Id);

            // 3. ساختاردهی درختی
            var roots = new List<GetAllCommentsDto>();

            foreach (var dto in dict.Values)
            {
                if (dto.ReplayId.HasValue && dict.TryGetValue(dto.ReplayId.Value, out var parentDto))
                {
                    parentDto.Replies.Add(dto);
                }
                else
                {
                    roots.Add(dto);
                }
            }

            // 4. بازگشت لیست ریشه‌ها
            return roots;
        }
    }
}
