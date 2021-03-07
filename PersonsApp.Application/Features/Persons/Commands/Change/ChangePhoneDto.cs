using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Commands.Change
{

    public class ChangePhoneNumberDto
    {
        public int PhoneTypeId { get; set; }
        public string Number { get; set; }
    }
}
