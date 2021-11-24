using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employees.Commands.DeleteEmployeeCommand
{
    public class DeleteEmployeeCommand : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
