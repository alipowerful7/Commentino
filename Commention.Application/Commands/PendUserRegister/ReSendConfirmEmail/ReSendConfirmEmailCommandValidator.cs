using FluentValidation;

namespace Commention.Application.Commands.PendUserRegister.ReSendConfirmEmail
{
    public class ReSendConfirmEmailCommandValidator : AbstractValidator<ReSendConfirmEmailCommand>
    {
        public ReSendConfirmEmailCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("آیدی کاربر نمی تواند خالی باشد.");
        }
    }
}
