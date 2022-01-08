using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employees.Queries.GetEmployeeByEmailQuery
{
    public class GetEmployeeByEmailQuery : IRequest<Employee>
    {
        public string Email { get; set; }
    }
}
