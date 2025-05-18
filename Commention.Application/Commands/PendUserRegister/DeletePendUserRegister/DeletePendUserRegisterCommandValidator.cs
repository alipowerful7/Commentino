using FluentValidation;

namespace Commention.Application.Commands.PendUserRegister.DeletePendUserRegister
{
    public class DeletePendUserRegisterCommandValidator : AbstractValidator<DeletePendUserRegisterCommand>
    {
        public DeletePendUserRegisterCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("آیدی نمی تواند خالی باشد.");
        }
    }
}
