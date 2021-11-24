using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Jobs.Commands.DeleteJobCommand
{
    public class DeleteJobCommand : IRequest<Job>
    {
        public int Id { get; set; }
    }
}
