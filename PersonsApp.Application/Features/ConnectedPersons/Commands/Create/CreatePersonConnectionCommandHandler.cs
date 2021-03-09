using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
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
        //private readonly IStringLocalizer _localizer;
        private readonly IMapper _mapper;

        public CreatePersonConnectionCommandHandler(IPersonConnectionRepository personConnectionRepository, IMapper mapper)//, IStringLocalizer localizer)
        {
            _personConnectionRepository = personConnectionRepository;
            _mapper = mapper;
            //_localizer = localizer;
        }

        public async Task<int> Handle(CreatePersonConnectionCommand request, CancellationToken cancellationToken)
        {
            if (request.ConnectedPersonId == request.PersonId)
                throw new BadRequestException("Can not add yourself as connected person");

            var dublicate = await _personConnectionRepository.PersonConnectionSearchAsync(request.ConnectionTypeId, request.PersonId, request.ConnectedPersonId);

            if (dublicate != null)
                throw new DublicateException("Connection Allready Exists");//_localizer["ConnectionAllreadyExists"]);

            var personConnection = _mapper.Map<PersonConnection>(request);

            personConnection = await _personConnectionRepository.AddAsync(personConnection);

            return personConnection.ID;
        }
    }
}
