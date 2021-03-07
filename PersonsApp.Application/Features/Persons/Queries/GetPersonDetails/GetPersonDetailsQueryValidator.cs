using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsCommandValidator : AbstractValidator<GetPersonDetailsQuery>
    {
        public GetPersonDetailsCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("{PropertyName} უნდა იყოს 0 ზე მეტი");
        }
    }
}
