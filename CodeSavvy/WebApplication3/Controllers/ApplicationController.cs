using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeSavvy.Application.Applications.Commands.CreateApplicationCommand;
using CodeSavvy.Application.Applications.Commands.DeleteApplicationCommand;
using CodeSavvy.Application.Applications.Commands.UpdateApplicationCommand;
using CodeSavvy.Application.Applications.Queries.GetApplicationByIdQuery;
using CodeSavvy.Application.Applications.Queries.GetApplicationsForEmployeeQuery;
using CodeSavvy.Application.Applications.Queries.GetApplicationsForJobQuery;
using CodeSavvy.Application.Employees.Queries.GetEmployeeByIdQuery;
using CodeSavvy.Application.Jobs.Queries.GetJobByIdQuery;
using CodeSavvy.Domain.Models;
using CodeSavvy.WebUI.ViewModels.ApplicationViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSavvy.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ApplicationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
            

        [HttpPost]
        public async Task<IActionResult> AddApplication(int jobId, int employeeId, [FromBody] CreateApplicationViewModel application)
        {
            var job = await _mediator.Send(new GetJobByIdQuery { Id = jobId } );
            var employee = await _mediator.Send(new GetEmployeeByIdQuery { Id = employeeId } );
            var map = _mapper.Map<CreateApplicationCommand>(application);
            map.Job = job;
            map.Employee = employee;
            var result = await _mediator.Send(map);
            return Ok(result);
        }

        [HttpGet("{id:int}/GetApplicationById", Name = "GetApplicationById")]
        public async Task<IActionResult> GetApplicationById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetApplicationByIdQuery {Id = id});
            return Ok(result);
        }

        [HttpGet("{employeeId:int}/GetApplicationForEmployeeId", Name = "GetApplicationForEmployeeId")]
        public async Task<IActionResult> GetApplicationsForEmployee([FromRoute] int employeeId)
        {
            //todo modify
            var result = await _mediator.Send(new GetApplicationsForEmployeeQuery {EmployeeId = employeeId});
            return Ok(result);
        }

        [HttpGet("{jobId:int}/GetApplicationForJobId", Name = "GetApplicationForJobId")]
        public async Task<IActionResult> GetApplicationsForJob([FromRoute] int jobId)
        {
            //todo modify
            var result = await _mediator.Send(new GetApplicationsForJobQuery {JobId = jobId});
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
            [FromBody] UpdateApplicationViewModel application)
        {
            var map = _mapper.Map<UpdateApplicationCommand>(application);
            map.Id = id;
            map.Id = 1002;     //test
            var result = await _mediator.Send(map);
            return Ok(result);
        }

    }
}
