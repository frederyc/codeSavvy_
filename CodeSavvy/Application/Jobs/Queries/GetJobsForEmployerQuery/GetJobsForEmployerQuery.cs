using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Jobs.Queries.GetJobsForEmployerQuery
{
    public class GetJobsForEmployerQuery : IRequest<List<Job>>
    {
        public int EmployerId { get; set; }
    }
}
