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
    public class GetPersonsListQueryHandler : IRequestHandler<GetPersonsListQuery, List<PersonListVm>>
    {

        private readonly IRepository<Person> _personRepository;
        private readonly IMapper _mapper;

        public GetPersonsListQueryHandler(IRepository<Person> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<List<PersonListVm>> Handle(GetPersonsListQuery request, CancellationToken cancellationToken)
        {
            var persons = (await _personRepository.ListAsync()).OrderBy(x => x.ID);

            return _mapper.Map<List<PersonListVm>>(persons);
        }
    }
}
