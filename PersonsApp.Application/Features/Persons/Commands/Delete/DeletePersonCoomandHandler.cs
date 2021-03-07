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
        private readonly IPersonConnectionRepository _personConnectionRepository;
        private readonly IMapper _mapper;

        public DeletePersonCoomandHandler(IPersonRepository personRepository, IMapper mapper, IPersonConnectionRepository personConnectionRepository)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _personConnectionRepository = personConnectionRepository;
        }

        public async Task<Unit> Handle(DeletePersonCoomand request, CancellationToken cancellationToken)
        {
            if (await _personConnectionRepository.CheckIfPersonIsConnectedAsync(request.Id))
                throw new BadRequestException("წაშლა შეუძლებელია პირი იძებნება დაკავშირებულთა სიაში");

            var toDelete = await _personRepository.GetOneByIdAsync(request.Id);

            if (toDelete is null)
                throw new NotFoundException("Person", request.Id.ToString());

            await _personRepository.DeleteAsync(toDelete);

            return Unit.Value;
        }
    }
}
