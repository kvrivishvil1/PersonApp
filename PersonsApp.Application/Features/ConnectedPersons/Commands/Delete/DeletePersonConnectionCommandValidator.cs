using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.ConnectedPersons.Commands.Delete
{
    public class DeletePersonConnectionCommandValidator : AbstractValidator<DeletePersonConnectionCommand>
    {
        public DeletePersonConnectionCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("{PropertyName} უნდა იყოს 0-ზე მეტი");
        }
    }
}
