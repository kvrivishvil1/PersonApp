﻿using AutoMapper;
using MediatR;
using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Application.Exceptions;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonsApp.Application.Features.ConnectedPersons.Commands.Create
{
    public class CreatePersonConnectionCommandHandler : IRequestHandler<CreatePersonConnectionCommand, int>
    {
        private readonly IPersonConnectionRepository _personConnectionRepository;
        private readonly IMapper _mapper;

        public CreatePersonConnectionCommandHandler(IPersonConnectionRepository personConnectionRepository, IMapper mapper)
        {
            _personConnectionRepository = personConnectionRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePersonConnectionCommand request, CancellationToken cancellationToken)
        {
            var dublicate = await _personConnectionRepository.PersonConnectionSearch(request.ConnectionTypeId, request.PersonId, request.ConnectedPersonId);

            if(dublicate != null)
                throw new DublicateException();

            var personConnection = _mapper.Map<PersonConnection>(request);

            personConnection = await _personConnectionRepository.AddAsync(personConnection);

            return personConnection.ID;
        }
    }
}