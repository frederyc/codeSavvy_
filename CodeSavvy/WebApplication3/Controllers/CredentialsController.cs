using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeSavvy.Application.Credentials.Commands;
using CodeSavvy.Application.Credentials.Commands.DeleteCredentialsCommand;
using CodeSavvy.Application.Credentials.Commands.UpdateCredentialsCommand;
using CodeSavvy.Application.Credentials.Queries.GetCredentialsByEmail;
using CodeSavvy.Application.Credentials.Queries.GetCredentialsById;
using CodeSavvy.WebUI.ViewModels.CredentialsViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSavvy.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CredentialsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CredentialsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCredentials([FromBody] CreateCredentialsViewModel credentials)
        {
            var map = _mapper.Map<CreateCredentialsCommand>(credentials);
            var result = await _mediator.Send(map);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetCredentialsById")]
        public async Task<IActionResult> GetCredentials([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetCredentialsById { Id = id} );
            return Ok(result);
        }

        [HttpGet("{email}", Name = "GetCredentialsByEmail")]
        public async Task<IActionResult> GetCredentials([FromRoute] string email)
        {
            var result = await _mediator.Send(new GetCredentialsByEmail {Email = email} );
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCredentials([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteCredentialsCommand { Id = id } );
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCredentials([FromRoute] int id, [FromBody] CreateCredentialsViewModel credentials)
        {
            var map = _mapper.Map<UpdateCredentialsCommand>(credentials);
            map.Id = id;
            var result = await _mediator.Send(map);
            return Ok(result);
        }

    }
}
