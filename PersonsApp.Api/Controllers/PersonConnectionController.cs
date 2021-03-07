using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonsApp.Api.Middlewares;
using PersonsApp.Application.Features.ConnectedPersons.Commands.Create;
using PersonsApp.Application.Features.ConnectedPersons.Commands.Delete;

namespace PersonsApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonConnectionController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PersonConnectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Adds connected person 
        /// </summary>
        /// <returns></returns>
        [HttpPut("Add")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Conflict)]
        public async Task<ActionResult<int>> Add(CreatePersonConnectionCommand command)
            => Ok(await _mediator.Send(command));

        /// <summary>
        /// Deletes connected person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeletePersonConnectionCommand { Id = id });
            return NoContent();
        }

        /// <summary>
        /// Report of connected persons 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Report")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public string ConnectedPersonsReport()
        {
            return "person1";
        }

    }
}
