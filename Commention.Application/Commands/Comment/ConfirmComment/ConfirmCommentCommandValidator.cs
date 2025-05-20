using FluentValidation;

namespace Commention.Application.Commands.Comment.ConfirmComment
{
    public class ConfirmCommentCommandValidator : AbstractValidator<ConfirmCommentCommand>
    {
        public ConfirmCommentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("آیدی کامنت نمی تواند خالی باشد.");
        }
    }
}
