using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeSavvy.Application.Credentials.Queries.GetCredentialsById;
using CodeSavvy.Application.Employers.Commands.CreateEmployerCommand;
using CodeSavvy.Application.Employers.Commands.DeleteEmployerCommand;
using CodeSavvy.Application.Employers.Commands.UpdateEmployerCommand;
using CodeSavvy.Application.Employers.Queries.GetEmployerByEmailQuery;
using CodeSavvy.Application.Employers.Queries.GetEmployerByIdQuery;
using CodeSavvy.Domain.Models;
using CodeSavvy.WebUI.ViewModels.EmployerViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSavvy.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EmployerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployer(int credentialsId, CreateEmployerViewModel employer)
        {
            var credentials = await _mediator.Send(new GetCredentialsById { Id = credentialsId });
            var map = _mapper.Map<CreateEmployerCommand>(employer);
            map.Credentials = credentials;
            var result = await _mediator.Send(map);
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = "DeleteEmployerById")]
        public async Task<IActionResult> DeleteEmployer(int id)
        {
            var result = await _mediator.Send(new DeleteEmployerCommand {Id = id});
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployer(int id, UpdateEmployerViewModel employer)
        {
            var map = _mapper.Map<UpdateEmployerCommand>(employer);
            map.Id = id;
            var result = await _mediator.Send(map);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetEmployerById")]
        public async Task<IActionResult> GetEmployer(int id)
        {
            var result = await _mediator.Send(new GetEmployerByIdQuery {Id = id});
            return Ok(result);
        }

        [HttpGet("{email}", Name = "GetEmployerByEmail")]
        public async Task<IActionResult> GetEmployer(string email)
        {
            var result = await _mediator.Send(new GetEmployerByEmailQuery {Email = email});
            return Ok(result);
        }

    }
}
