using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSavvy.Application.Credentials.Commands;
using CodeSavvy.Application.Credentials.Commands.DeleteCredentialsCommand;
using CodeSavvy.Application.Credentials.Commands.UpdateCredentialsCommand;
using CodeSavvy.Application.Credentials.Queries.GetCredentialsById;
using CodeSavvy.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSavvy.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CredentialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CredentialsController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> AddCredentials([FromBody] Credentials credentials)
        {
            var result = await _mediator.Send(new CreateCredentialsCommand {Credentials = credentials});
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetCredentialsById")]
        public async Task<IActionResult> GetCredentials([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetCredentialsById { Id = id} );
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCredentials([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteCredentialsCommand { Id = id } );
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCredentials([FromRoute] int id, [FromBody] Credentials credentials)
        {
            var result = await _mediator.Send(new UpdateCredentialsCommand
            {
                Id = id, 
                Credentials = credentials
            });
            return Ok(result);
        }

    }
}
