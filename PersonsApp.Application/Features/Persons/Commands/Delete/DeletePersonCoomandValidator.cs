using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Commands.Delete
{
    public class DeletePersonCoomandValidator : AbstractValidator<DeletePersonCoomand>
    {
        public DeletePersonCoomandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("{PropertyName} უნდა იყოს 0 ზე მეტი");
        }
    }
}
