using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employees.Queries.GetEmployeeByEmailQuery
{
    public class GetEmployeeByEmailQueryHandler : IRequestHandler<GetEmployeeByEmailQuery, Employee>
    {
        private readonly IEmployeeRepository _repo;

        public GetEmployeeByEmailQueryHandler(IEmployeeRepository repo)
        {
            _repo = repo;
        }


        public async Task<Employee> Handle(
            GetEmployeeByEmailQuery request,
            CancellationToken cancellationToken)
        {
            return await _repo.GetEmployee(request.Email);
        }
    }
}
