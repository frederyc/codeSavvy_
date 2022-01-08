using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Jobs.Queries.GetJobsForEmployerQuery
{
    public class GetJobsForEmployerQueryHandler : IRequestHandler<GetJobsForEmployerQuery, List<Job>>
    {
        private readonly IJobRepository _repo;
        
        public GetJobsForEmployerQueryHandler(IJobRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Job>> Handle(
            GetJobsForEmployerQuery request,
            CancellationToken cancellationToken)
        {
            return await _repo.GetJobs(request.EmployerId);
        }
    }
}
