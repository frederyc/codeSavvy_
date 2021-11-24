using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSavvy.Application.Employers.Commands.CreateEmployerCommand;
using CodeSavvy.Application.Employers.Commands.DeleteEmployerCommand;
using CodeSavvy.Application.Employers.Commands.UpdateEmployerCommand;
using CodeSavvy.Application.Employers.Queries.GetEmployerByIdQuery;
using CodeSavvy.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSavvy.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployerController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> AddEmployer(Employer employer)
        {
            var result = await _mediator.Send(new CreateEmployerCommand {Employer = employer});
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = "DeleteEmployerById")]
        public async Task<IActionResult> DeleteEmployer(int id)
        {
            var result = await _mediator.Send(new DeleteEmployerCommand {Id = id});
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployer(int id, Employer employer)
        {
            var result = await _mediator.Send(new UpdateEmployerCommand
            {
                Id = id,
                Employer = employer
            });
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetEmployerById")]
        public async Task<IActionResult> GetEmployer(int id)
        {
            var result = await _mediator.Send(new GetEmployerByIdQuery {Id = id});
            return Ok(result);
        }

    }
}
