using FluentValidation;

namespace Commention.Application.Queries.User.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("آیدی کاربر نمی تواند خالی باشد.");
        }
    }
}
