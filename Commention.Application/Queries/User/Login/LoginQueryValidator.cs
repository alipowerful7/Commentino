using FluentValidation;

namespace Commention.Application.Queries.User.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("نام کاربری نمی تواند خالی باشد.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("رمز عبور نمی تواند خالی باشد.");
        }
    }
}
