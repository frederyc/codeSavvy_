using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Jobs.Queries.GetJobsQuery
{
    public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, List<Job>>
    {
        private readonly IJobRepository _repo;

        public GetJobsQueryHandler(IJobRepository repo)
        {
            _repo = repo;
        }


        public async Task<List<Job>> Handle(
            GetJobsQuery request, 
            CancellationToken cancellationToken)
        {
            return await _repo.GetJobs(request.Location, request.Position, request.Level, request.Salary);
        }
    }
}
