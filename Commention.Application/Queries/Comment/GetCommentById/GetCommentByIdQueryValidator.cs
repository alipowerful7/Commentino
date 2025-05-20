using FluentValidation;

namespace Commention.Application.Queries.Comment.GetCommentById
{
    public class GetCommentByIdQueryValidator : AbstractValidator<GetCommentByIdQuery>
    {
        public GetCommentByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("آیدی کامنت نمی تواند خالی باشد.");
        }
    }
}
