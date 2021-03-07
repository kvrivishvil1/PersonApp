using FluentValidation;
using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonsApp.Application.Features.ConnectedPersons.Commands.Create
{
    public class CreatePersonConnectionCommandValidator : AbstractValidator<CreatePersonConnectionCommand>
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<PersonConnectionType> _connectionTypeRepository;

        public CreatePersonConnectionCommandValidator(IRepository<Person> personRepository, IRepository<PersonConnectionType> connectionTypeRepository)
        {
            _personRepository = personRepository;
            _connectionTypeRepository = connectionTypeRepository;

            RuleFor(x => x.ConnectionTypeId)
                .MustAsync(ConnectionTypeExists).WithMessage("{PropertyName} არ არსებობს");

            RuleFor(x => x.PersonId)
                .MustAsync(PersonExists).WithMessage("{PropertyName} არ არსებობს");

            RuleFor(x => x.ConnectedPersonId)
                .MustAsync(PersonExists).WithMessage("{PropertyName} არ არსებობს");
        }


        private async Task<bool> PersonExists(int id, CancellationToken token)
        {
            if (id <= 0)
                return false;

            var result = await _personRepository.GetOneByIdAsync(id);
            if (result is null)
                return false;

            return true;
        }
        private async Task<bool> ConnectionTypeExists(int id, CancellationToken token)
        {
            if (id <= 0)
                return false;

            var result = await _connectionTypeRepository.GetOneByIdAsync(id);
            if (result is null)
                return false;

            return true;
        }
    }
}
