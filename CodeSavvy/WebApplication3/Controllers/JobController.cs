using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSavvy.Application.Jobs.Commands.CreateJobCommand;
using CodeSavvy.Application.Jobs.Commands.DeleteJobCommand;
using CodeSavvy.Application.Jobs.Commands.UpdateJobCommand;
using CodeSavvy.Application.Jobs.Queries.GetJobByIdQuery;
using CodeSavvy.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSavvy.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> AddJob(Job job)
        {
            var result = await _mediator.Send(new CreateJobCommand {Job = job});
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = "DeleteJobById")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var result = await _mediator.Send(new DeleteJobCommand {Id = id});
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJob(int id, Job job)
        {
            var result = await _mediator.Send(new UpdateJobCommand
            {
                Id = id,
                Job = job
            });
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetJobById")]
        public async Task<IActionResult> GetJob(int id)
        {
            var result = await _mediator.Send(new GetJobByIdQuery {Id = id});
            return Ok(result);
        }

    }
}
