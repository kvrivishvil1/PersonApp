using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.ConnectedPersons.Commands.Create
{
    public class CreatePersonConnectionCommand: IRequest<int>
    {
        public int ConnectionTypeId { get; set; }
        public int PersonId { get; set; }
        public int ConnectedPersonId { get; set; }
    }
}
