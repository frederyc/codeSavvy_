using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employees.Commands.CreateEmployeeCommand
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public Domain.Models.Credentials Credentials { get; set; }
        public string FullName { get; set; }
    }
}
