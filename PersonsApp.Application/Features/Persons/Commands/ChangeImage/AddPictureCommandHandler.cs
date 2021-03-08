using MediatR;
using PersonsApp.Application.Contracts.Persistance;
using PersonsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonsApp.Application.Features.Persons.Commands.ChangeImage
{
    public class AddPictureCommandHandler : IRequestHandler<AddPictureCommand>
    {
        private readonly IRepository<Person> _personRepository;

        public AddPictureCommandHandler(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Unit> Handle(AddPictureCommand request, CancellationToken cancellationToken)
        {
            if(request.Image.Length > 0)
            {
                var person = await _personRepository.GetOneByIdAsync(request.PersonId);

                string path =  $"Files/Images/Person/{request.PersonId}/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(request.Image.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    request.Image.CopyTo(stream);
                }

                person.Image = Path.Combine(path, fileName);

                await _personRepository.UpdateAsync(person);
            }

            return Unit.Value;
        }
    }
}
