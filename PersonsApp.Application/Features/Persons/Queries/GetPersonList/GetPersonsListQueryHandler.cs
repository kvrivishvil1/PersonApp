using AutoMapper;
using MediatR;
using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonsApp.Application.Features.Persons.Queries.GetPersonList
{
    public class GetPersonsListQueryHandler : IRequestHandler<GetPersonsListQuery, IEnumerable<PersonListVm>>
    {

        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetPersonsListQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonListVm>> Handle(GetPersonsListQuery request, CancellationToken cancellationToken)
        {
            //var persons = (await _personRepository.ListAsync()).OrderBy(x => x.ID);
            var persons = await _personRepository.PersonSearchAsync(request);

            return _mapper.Map<IEnumerable<PersonListVm>>(persons);
        }
    }
}
