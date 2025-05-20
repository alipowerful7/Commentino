using Commention.Domain.Interfaces;
using FluentValidation;

namespace Commention.Application.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        public UpdateCommentCommandValidator(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("آیدی نمی تواند خالی باشد.");
            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("متن کامنت نمی تواند خالی باشد.");
            RuleFor(x => x)
                .MustAsync(async (cmd, ct) =>
                {
                    // اگر وجود داشت خطا
                    var exists = await _commentRepository.IsCommentConfirm(cmd.Id);
                    return !exists;
                })
                .WithMessage("کامنتی که تایید شده باشد را نمی توان ویرایش کرد.");
        }
    }
}
