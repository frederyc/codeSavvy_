using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeSavvy.Application.Employers.Queries.GetEmployerByIdQuery;
using CodeSavvy.Application.Jobs.Commands.CreateJobCommand;
using CodeSavvy.Application.Jobs.Commands.DeleteJobCommand;
using CodeSavvy.Application.Jobs.Commands.UpdateJobCommand;
using CodeSavvy.Application.Jobs.Queries.GetJobByIdQuery;
using CodeSavvy.Application.Jobs.Queries.GetJobsForEmployerQuery;
using CodeSavvy.Application.Jobs.Queries.GetJobsQuery;
using CodeSavvy.Domain.Models;
using CodeSavvy.WebUI.ViewModels.JobViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSavvy.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public JobController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
            

        [HttpPost]
        public async Task<IActionResult> AddJob(int employerId, CreateJobViewModel job)
        {
            var employer = await _mediator.Send(new GetEmployerByIdQuery {Id = employerId} );
            var map = _mapper.Map<CreateJobCommand>(job);
            map.Employer = employer;
            var result = await _mediator.Send(map);
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = "DeleteJobById")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var result = await _mediator.Send(new DeleteJobCommand {Id = id});
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJob(int id, CreateJobViewModel job)
        {
            var map = _mapper.Map<UpdateJobCommand>(job);
            map.Id = id;
            var result = await _mediator.Send(map);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetJobById")]
        public async Task<IActionResult> GetJob(int id)
        {
            var result = await _mediator.Send(new GetJobByIdQuery {Id = id});
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs(int location, int position, int level, int salary)
        {
            var result = await _mediator.Send(new GetJobsQuery
            {
                Location = location,
                Position = position,
                Level = level,
                Salary = salary
            });
            return Ok(result);
        }

        [HttpGet("{employerId:int}/GetJobsForEmployer", Name = "GetJobsForEmployer")]
        public async Task<IActionResult> GetJobs(int employerId)
        {
            var result = await _mediator.Send(new GetJobsForEmployerQuery {EmployerId = employerId});
            return Ok(result);
        }

    }
}
