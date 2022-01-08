using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Jobs.Queries.GetJobsQuery
{
    public class GetJobsQuery : IRequest<List<Job>>
    {
        public int Location { get; set; }
        public int Position { get; set; }
        public int Level { get; set; }
        public int Salary { get; set; }
    }
}
