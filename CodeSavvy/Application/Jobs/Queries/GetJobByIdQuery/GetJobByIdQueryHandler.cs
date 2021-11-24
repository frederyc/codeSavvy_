using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Jobs.Queries.GetJobByIdQuery
{
    public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, Job>
    {
        private readonly IJobRepository _repo;

        public GetJobByIdQueryHandler(IJobRepository repo)
            => _repo = repo;

        public async Task<Job> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
            => await _repo.GetJob(request.Id);
    }
}
