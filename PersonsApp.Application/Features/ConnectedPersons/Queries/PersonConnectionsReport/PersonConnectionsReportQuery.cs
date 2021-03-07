using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.ConnectedPersons.Queries.PersonConnectionsReport
{
    public class PersonConnectionsReportQuery : IRequest<IEnumerable<PersonConnectionReportVm>>
    {
    }
}
