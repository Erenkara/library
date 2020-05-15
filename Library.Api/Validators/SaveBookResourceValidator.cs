using FluentValidation;
using Library.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Validators
{
    public class SaveBookResourceValidator : AbstractValidator<SaveBookResource>
    {
        public SaveBookResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(a => a.ISBN)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.AuthorId)
               .NotEmpty()
               .WithMessage("'Author Id' must not be 0.");
        }
    }
}
