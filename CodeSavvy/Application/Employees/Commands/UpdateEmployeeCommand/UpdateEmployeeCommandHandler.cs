using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employees.Commands.UpdateEmployeeCommand
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _repo;

        public UpdateEmployeeCommandHandler(IEmployeeRepository repo)
            => _repo = repo;

        public async Task<Employee> Handle(
            UpdateEmployeeCommand request,
            CancellationToken cancellationToken)
            => await _repo.UpdateEmployee(request.Id, request.Employee);
    }
}
