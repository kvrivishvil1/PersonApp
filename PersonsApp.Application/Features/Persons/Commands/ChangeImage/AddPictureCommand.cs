using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsApp.Application.Features.Persons.Commands.ChangeImage
{
    public class AddPictureCommand : IRequest
    {
        public int PersonId { get; set; }
        public IFormFile Image { get; set; }

    }
}
