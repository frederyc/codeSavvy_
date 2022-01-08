using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using MediatR;

namespace CodeSavvy.Application.Applications.Queries.GetApplicationsForEmployeeQuery
{
    public class GetApplicationsForEmployeeQueryHandler :
        IRequestHandler<GetApplicationsForEmployeeQuery, List<Domain.Models.Application>>
    {
        private readonly IApplicationRepository _repo;

        public GetApplicationsForEmployeeQueryHandler(IApplicationRepository repo)
            => _repo = repo;

        public async Task<List<Domain.Models.Application>> Handle(
            GetApplicationsForEmployeeQuery request,
            CancellationToken cancellationToken)
            => await _repo.GetApplicationsForEmployee(request.EmployeeId);
    }
}
