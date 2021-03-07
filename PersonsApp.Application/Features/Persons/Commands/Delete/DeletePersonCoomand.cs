using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Commands.Delete
{
    public class DeletePersonCoomand : IRequest
    {
        public int Id { get; set; }
    }
}
