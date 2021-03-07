using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.ConnectedPersons.Queries.PersonConnectionsReport
{
    public class PersonConnectionReportVm
    {
        public string Person { get; set; }
        public string ConnectionType { get; set; }
        public int Count { get; set; }
    }
}
