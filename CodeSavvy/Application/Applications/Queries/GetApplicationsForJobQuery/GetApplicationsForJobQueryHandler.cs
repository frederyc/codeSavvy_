using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using MediatR;

namespace CodeSavvy.Application.Applications.Queries.GetApplicationsForJobQuery
{
    public class GetApplicationsForJobQueryHandler :
        IRequestHandler<GetApplicationsForJobQuery, List<Domain.Models.Application>>
    {
        private readonly IApplicationRepository _repo;

        public GetApplicationsForJobQueryHandler(IApplicationRepository repo)
            => _repo = repo;

        public async Task<List<Domain.Models.Application>> Handle(
            GetApplicationsForJobQuery request,
            CancellationToken cancellationToken)
        {

            return await _repo.GetApplicationsForJob(request.JobId);
        }
    }
}
