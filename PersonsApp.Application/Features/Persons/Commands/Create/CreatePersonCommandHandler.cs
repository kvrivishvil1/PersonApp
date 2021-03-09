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

namespace PersonsApp.Application.Features.Persons.Commands.Create
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IPersonRepository _personRepository;
        //private readonly IStringLocalizer _localizer;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)//, IStringLocalizer localizer)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            //_localizer = localizer;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var dublicate = await _personRepository.GetPersonGetWithPersonalNAsync(request.PersonalN);
            if (dublicate != null)
                throw new DublicateException("Person Allready Exists");//_localizer["PersonWithPersonalnExists"]);

            var @person = _mapper.Map<Person>(request);

            @person = await _personRepository.AddAsync(@person);

            return @person.ID;
        }
    }
}
