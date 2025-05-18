using Commention.Domain.Interfaces;
using FluentValidation;

namespace Commention.Application.Commands.User.CreateUser
{
    public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
    {
        private readonly IPendUserRegisterRepository _pendUserRegisterRepository;
        public CreateUserCommandValidator(IPendUserRegisterRepository pendUserRegisterRepository)
        {
            _pendUserRegisterRepository = pendUserRegisterRepository;
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("ایمیل نمی تواند خالی باشد.")
                .EmailAddress().WithMessage("فرمت ایمیل نادرست می باشد.");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("نام کاربری نمی تواند خالی باشد.");
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("نام نمی تواند حالی باشد.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("نام خانوادگی نمی تواند خالی باشد.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("رمز عبور نمی تواند خالی باشد.");
            RuleFor(x => x.UserRole)
                .NotEmpty().WithMessage("نقش کاربر نمی تواند خالی باشد.");
            RuleFor(x => x)
                .MustAsync(async (cmd, ct) =>
                {
                    // اگر وجود داشت خطا
                    var exists = await _pendUserRegisterRepository.IsPendUserRegisterExistsAsync(cmd.UserName!, cmd.Email!);
                    return !exists;
                })
                .WithMessage("ایمیل یا نام کاربری تکراری است.");
        }
    }
}
