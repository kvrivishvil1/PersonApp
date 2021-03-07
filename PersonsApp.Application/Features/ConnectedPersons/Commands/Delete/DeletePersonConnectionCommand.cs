using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.ConnectedPersons.Commands.Delete
{
    public class DeletePersonConnectionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
