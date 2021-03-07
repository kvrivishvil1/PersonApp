using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Queries.GetPersonList
{
    public class GetPersonsListQueryValidator : AbstractValidator<GetPersonsListQuery>
    {
        public GetPersonsListQueryValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().NotEmpty().WithMessage("{PropertyName} აუცილებელია");

        }
    }
}
