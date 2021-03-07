using MediatR;
using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Application.Exceptions;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonsApp.Application.Features.ConnectedPersons.Commands.Delete
{
    public class DeletePersonConnectionCommandHandler : IRequestHandler<DeletePersonConnectionCommand>
    {
        private readonly IRepository<PersonConnection> _repository;

        public DeletePersonConnectionCommandHandler(IRepository<PersonConnection> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePersonConnectionCommand request, CancellationToken cancellationToken)
        {
            var toDelete = await _repository.GetOneByIdAsync(request.Id);

            if (toDelete is null)
                throw new NotFoundException("PersonConnection", request.Id.ToString());

            await _repository.DeleteAsync(toDelete);

            return Unit.Value;
        }
    }
}
