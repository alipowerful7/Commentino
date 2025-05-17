using FluentValidation;

namespace Commention.Application.Commands.PendUserRegister.ConfirmEmail
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("آیدی نمی تواند خالی باشد.");
            RuleFor(x => x.ConfirmCode)
                .NotEmpty().WithMessage("کد تایید نمی تواند خالی باشد.");
        }
    }
}
