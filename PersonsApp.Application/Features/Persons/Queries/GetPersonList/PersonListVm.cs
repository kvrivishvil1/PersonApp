﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Queries.GetPersonList
{
    public class PersonListVm
    {
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalN { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Image { get; set; }
    }
}
