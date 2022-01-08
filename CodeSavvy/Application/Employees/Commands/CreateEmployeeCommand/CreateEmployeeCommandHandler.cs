using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employees.Commands.CreateEmployeeCommand
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _repo;

        public CreateEmployeeCommandHandler(IEmployeeRepository repo)
            => _repo = repo;

        public async Task<Employee> Handle(
            CreateEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var employee = new Employee()
            {
                FullName = request.FullName,
                Credentials = request.Credentials
            };
            return await _repo.CreateEmployee(employee);
        }
    }
}
