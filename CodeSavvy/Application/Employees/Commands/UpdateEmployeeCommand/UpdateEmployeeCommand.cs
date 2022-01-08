using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employees.Commands.UpdateEmployeeCommand
{
    public class UpdateEmployeeCommand : IRequest<Employee>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
