using AutoMapper;
using MediatR;
using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonsApp.Application.Features.Persons.Commands.Change
{
    public class ChangePersonCommandHandler : IRequestHandler<ChangePersonCommand>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public ChangePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ChangePersonCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _personRepository.GetOneByIdAsync(request.Id);

            _mapper.Map(request, toUpdate, typeof(ChangePersonCommand), typeof(Person));

            await _personRepository.UpdateAsync(toUpdate);

            return Unit.Value;
        }
    }
}
