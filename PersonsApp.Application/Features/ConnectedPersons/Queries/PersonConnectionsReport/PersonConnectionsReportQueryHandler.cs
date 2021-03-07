﻿using MediatR;
using PersonsApp.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonsApp.Application.Features.ConnectedPersons.Queries.PersonConnectionsReport
{
    public class PersonConnectionsReportQueryHandler : IRequestHandler<PersonConnectionsReportQuery, IEnumerable<PersonConnectionReportVm>>
    {
        private readonly IPersonConnectionRepository _personConnectionRepository;

        public PersonConnectionsReportQueryHandler(IPersonConnectionRepository personConnectionRepository)
        {
            _personConnectionRepository = personConnectionRepository;
        }

        public async Task<IEnumerable<PersonConnectionReportVm>> Handle(PersonConnectionsReportQuery request, CancellationToken cancellationToken)
        {
            var connections = await _personConnectionRepository.ListForReportAsync();

            return connections.GroupBy(x => 
                            new { 
                                x.PersonId, 
                                x.Person.FirstName, 
                                x.Person.LastName, 
                                x.ConnectionTypeId, 
                                x.ConnectionType.Name 
                            })
                        .Select(x => 
                            new PersonConnectionReportVm { 
                                Person = $"{x.Key.FirstName} {x.Key.LastName}",
                                ConnectionType = x.Key.Name,
                                Count = x.Count()
                            });
        }
    }
}
