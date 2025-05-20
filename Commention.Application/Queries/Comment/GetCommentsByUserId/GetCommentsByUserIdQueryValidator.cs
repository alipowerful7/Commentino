using FluentValidation;

namespace Commention.Application.Queries.Comment.GetCommentsByUserId
{
    public class GetCommentsByUserIdQueryValidator : AbstractValidator<GetCommentsByUserIdQuery>
    {
        public GetCommentsByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("آیدی کاربر نمی تواند خالی باشد.");
        }
    }
}
