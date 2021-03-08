using FluentValidation;
using Microsoft.Extensions.Localization;
using PersonsApp.Application.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsCommandValidator : AbstractValidator<GetPersonDetailsQuery>
    {
        public GetPersonDetailsCommandValidator(IStringLocalizer<FluentValidationMessages> localizer)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage(localizer["MustBeGreaterThan", "{PropertyName}", 0]);
        }
    }
}
