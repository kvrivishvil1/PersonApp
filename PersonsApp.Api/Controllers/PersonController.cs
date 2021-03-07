using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonsApp.Api.Middlewares;
using PersonsApp.Application.Features.Persons.Commands.Change;
using PersonsApp.Application.Features.Persons.Commands.Create;
using PersonsApp.Application.Features.Persons.Commands.Delete;
using PersonsApp.Application.Features.Persons.Queries.GetPersonDetails;
using PersonsApp.Application.Features.Persons.Queries.GetPersonList;
using PersonsApp.Domain.Entities;

namespace PersonsApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Gets Person Info From DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<PersonVm>> Get(int id)
            => Ok(await _mediator.Send(new GetPersonDetailsQuery { Id = id }));


        /// <summary>
        /// Saves New Person In Database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Save")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Conflict)]
        public async Task<ActionResult<int>> Save(CreatePersonCommand command)
            => Ok(await _mediator.Send(command));


        /// <summary>
        /// Updates Person Info In Database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Change")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Change(ChangePersonCommand command)
            => Ok(await _mediator.Send(command));


        /// <summary>
        /// Adds Picture On Person
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpPost("AddPicture")]
        public string AddPicture()
        {
            return "person1";
        }


        /// <summary>
        /// Deletes Person From Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Delete(int id)
            => Ok(await _mediator.Send(new DeletePersonCoomand { Id = id }));


        /// <summary>
        /// Fast Search Of Persons 
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [HttpPost("FastSearch")]
        public async Task<ActionResult> FastSearch(GetPersonsListQuery command)
            => Ok(await _mediator.Send(command));


        /// <summary>
        /// Detailed Search Of Persons
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [HttpPost("DetailedSearch")]
        public string DetailedSearch()
        {
            return "person1";
        }

    }
}
