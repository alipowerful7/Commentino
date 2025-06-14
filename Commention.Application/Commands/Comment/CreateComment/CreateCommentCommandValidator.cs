﻿using FluentValidation;

namespace Commention.Application.Commands.Comment.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("متن کامنت نمی تواند خالی باشد.");
        }
    }
}
