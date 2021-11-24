using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employees.Commands.DeleteEmployeeCommand
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _repo;

        public DeleteEmployeeCommandHandler(IEmployeeRepository repo)
            => _repo = repo;

        public async Task<Employee> Handle(
            DeleteEmployeeCommand request,
            CancellationToken cancellationToken)
            => await _repo.DeleteEmployee(request.Id);
    }
}
