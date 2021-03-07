using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Queries.GetPersonList
{
    public class GetPersonsListQuery: IRequest<List<PersonListVm>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalN { get; set; }
    }
}
