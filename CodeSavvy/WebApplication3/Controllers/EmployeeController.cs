using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeSavvy.Application.Credentials.Queries.GetCredentialsById;
using CodeSavvy.Application.Employees.Commands.CreateEmployeeCommand;
using CodeSavvy.Application.Employees.Commands.DeleteEmployeeCommand;
using CodeSavvy.Application.Employees.Commands.UpdateEmployeeCommand;
using CodeSavvy.Application.Employees.Queries.GetEmployeeByEmailQuery;
using CodeSavvy.Application.Employees.Queries.GetEmployeeByIdQuery;
using CodeSavvy.Domain.Models;
using CodeSavvy.WebUI.ViewModels.EmployeeViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSavvy.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EmployeeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
            

        [HttpPost]
        public async Task<IActionResult> AddEmployee(int credentialsId, CreateEmployeeViewModel employee)
        {
            var credentials = await _mediator.Send(new GetCredentialsById { Id = credentialsId } );
            var map = _mapper.Map<CreateEmployeeCommand>(employee);
            map.Credentials = credentials;
            var result = await _mediator.Send(map);
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = "DeleteEmployeeById")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand {Id = id});

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeViewModel employee)
        {
            var map = _mapper.Map<UpdateEmployeeCommand>(employee);
            map.Id = id;
            var result = await _mediator.Send(map);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery {Id = id});
            return Ok(result);
        }

        [HttpGet("{email}", Name="GetEmployeeByCredentialsEmail")]
        public async Task<IActionResult> GetEmployee(string email)
        {
            var result = await _mediator.Send(new GetEmployeeByEmailQuery {Email = email});
            return Ok(result);
        }


    }
}
