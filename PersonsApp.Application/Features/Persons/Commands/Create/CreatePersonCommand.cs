using MediatR;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Commands.Create
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalN { get; set; }
        public DateTime? BirthDate { get; set; }

        public int GenderId { get; set; }
        public int CityId { get; set; }

        public IEnumerable<CreatePhoneNumberDto> PhoneNumbers { get; set; }
    }


}
