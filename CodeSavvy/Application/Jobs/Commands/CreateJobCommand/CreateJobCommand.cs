using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Jobs.Commands.CreateJobCommand
{
    public class CreateJobCommand : IRequest<Job>
    {
        public Job Job { get; set; }
    }
}
