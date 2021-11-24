using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSavvy.Application.Employees.Commands.CreateEmployeeCommand;
using CodeSavvy.Application.Employees.Commands.DeleteEmployeeCommand;
using CodeSavvy.Application.Employees.Commands.UpdateEmployeeCommand;
using CodeSavvy.Application.Employees.Queries.GetEmployeeByIdQuery;
using CodeSavvy.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeSavvy.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var result = await _mediator.Send(new CreateEmployeeCommand {Employee = employee});
            return Ok(result);
        }

        [HttpDelete("{id:int}", Name = "DeleteEmployeeById")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand {Id = id});
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            var result = await _mediator.Send(new UpdateEmployeeCommand
            {
                Id = id, 
                Employee = employee
            });
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery {Id = id});
            return Ok(result);
        }

    }
}
