using FluentValidation;

namespace Commention.Application.Commands.User.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("نام کاربر نمی تواند خالی باشد.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("نام خانوادگی کاربر نمی تواند خالی باشد.");
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("آیدی کاربر نمی تواند خالی باشد.");
        }
    }
}
