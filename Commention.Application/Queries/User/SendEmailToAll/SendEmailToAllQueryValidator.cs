using FluentValidation;

namespace Commention.Application.Queries.User.SendEmailToAll
{
    public class SendEmailToAllQueryValidator : AbstractValidator<SendEmailToAllQuery>
    {
        public SendEmailToAllQueryValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("عنوان ایمیل نمی تواند خالی باشد.");
            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("متن ایمیل نمی تواند خالی باشد.");
        }
    }
}
