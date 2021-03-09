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

namespace PersonsApp.Application.Features.Persons.Commands.Change
{
    public class ChangePersonCommandHandler : IRequestHandler<ChangePersonCommand>
    {
        private readonly IPersonRepository _personRepository;
        //private readonly IStringLocalizer _localizer;
        private readonly IMapper _mapper;

        public ChangePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)//, IStringLocalizer localizer)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            //_localizer = localizer;
        }

        public async Task<Unit> Handle(ChangePersonCommand request, CancellationToken cancellationToken)
        {
            var dublicate = await _personRepository.GetPersonGetWithPersonalNAsync(request.PersonalN);
            var toUpdate = await _personRepository.GetOneWithPhoneNumbersAsync(request.Id);
            if (dublicate != null && dublicate.ID != toUpdate.ID)
                throw new DublicateException("Person Allready Exists");//_localizer["PersonWithPersonalnExists"]);

            _mapper.Map(request, toUpdate, typeof(ChangePersonCommand), typeof(Person));

            await _personRepository.UpdateAsync(toUpdate);

            return Unit.Value;
        }
    }
}
