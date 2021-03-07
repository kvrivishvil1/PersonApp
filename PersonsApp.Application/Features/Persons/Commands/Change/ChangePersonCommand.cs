﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Commands.Change
{
    public class ChangePersonCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalN { get; set; }
        public DateTime? BirthDate { get; set; }
        public int GenderId { get; set; }
        public int CityId { get; set; }
    }
}
