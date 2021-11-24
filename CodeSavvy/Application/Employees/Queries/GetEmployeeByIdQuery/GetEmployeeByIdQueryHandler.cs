using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employees.Queries.GetEmployeeByIdQuery
{
    public class GetEmployeeByIdQueryHandler : 
        IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeRepository _repo;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository repo)
            => _repo = repo;

        public async Task<Employee> Handle(
            GetEmployeeByIdQuery request,
            CancellationToken cancellationToken)
            => await _repo.GetEmployee(request.Id);
    }
}
