using FluentValidation;
using Library.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Validators
{
    public class SaveAuthorResourceValidator:AbstractValidator<SaveAuthorResource>
    {
        public SaveAuthorResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
