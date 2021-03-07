using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQuery : IRequest<PersonVm>
    {
        public int Id { get; set; }
    }
}
