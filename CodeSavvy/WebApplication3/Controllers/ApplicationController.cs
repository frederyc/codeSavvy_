using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSavvy.Application.Applications.CreateApplicationCommand;
using CodeSavvy.Application.Applications.DeleteApplicationCommand;
using CodeSavvy.Application.Applications.Queries.GetApplicationByIdQuery;
using CodeSavvy.Application.Applications.Queries.GetApplicationsForEmployeeQuery;
using CodeSavvy.Application.Applications.Queries.GetApplicationsForJobQuery;
using CodeSavvy.Application.Applications.UpdateApplicationCommand;
using CodeSavvy.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSavvy.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> AddApplication([FromBody] Domain.Models.Application application)
        {
            var result = await _mediator.Send(new CreateApplicationCommand {Application = application});
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetApplicationById")]
        public async Task<IActionResult> GetApplicationById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetApplicationByIdQuery {Id = id});
            return Ok(result);
        }

        [HttpGet("{employee}", Name = "GetApplicationForEmployee")]
        public async Task<IActionResult> GetApplicationsForEmployee([FromBody] Employee employee)
        {
            var result = await _mediator.Send(new GetApplicationsForEmployeeQuery {Employee = employee});
            return Ok(result);
        }

        [HttpGet("{job}", Name = "GetApplicationForJob")]
        public async Task<IActionResult> GetApplicationsForJob([FromBody] Job job)
        {
            var result = await _mediator.Send(new GetApplicationsForJobQuery {Job = job});
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteApplication([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteApplicationCommand {Id = id});
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(
            [FromRoute] int id,
            [FromBody] Domain.Models.Application application)
        {
            var result = await _mediator.Send(new UpdateApplicationCommand
            {
                Id = id,
                Application = application
            });
            return Ok(result);
        }

    }
}
