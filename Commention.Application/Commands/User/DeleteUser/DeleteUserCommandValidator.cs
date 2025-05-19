using FluentValidation;

namespace Commention.Application.Commands.User.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("آیدی کاربر نمی تواند خالی باشد.");
        }
    }
}
