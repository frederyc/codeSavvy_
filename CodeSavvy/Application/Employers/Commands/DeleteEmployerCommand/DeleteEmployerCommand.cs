using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employers.Commands.DeleteEmployerCommand
{
    public class DeleteEmployerCommand : IRequest<Employer>
    {
        public int Id { get; set; }
    }
}
