using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Commands.Create
{

    public class CreatePhoneNumberDto
    {
        public int PhoneTypeId { get; set; }
        public string Number { get; set; }
    }
}
