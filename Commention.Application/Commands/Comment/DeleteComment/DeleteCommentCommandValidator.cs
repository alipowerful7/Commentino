using FluentValidation;

namespace Commention.Application.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("آیدی کامنت نمی تواند خالی باشد.");
        }
    }
}
