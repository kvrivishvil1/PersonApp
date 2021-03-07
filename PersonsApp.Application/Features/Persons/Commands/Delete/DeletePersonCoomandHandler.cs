using AutoMapper;
using MediatR;
using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Application.Exceptions;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonsApp.Application.Features.Persons.Commands.Delete
{
    public class DeletePersonCoomandHandler : IRequestHandler<DeletePersonCoomand>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public DeletePersonCoomandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePersonCoomand request, CancellationToken cancellationToken)
        {
            var toDelete = await _personRepository.GetOneByIdAsync(request.Id);

            if (toDelete is null)
                throw new NotFoundException("Person", request.Id.ToString());

            await _personRepository.DeleteAsync(toDelete);

            return Unit.Value;
        }
    }
}
