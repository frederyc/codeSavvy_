using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using MediatR;

namespace CodeSavvy.Application.Applications.Queries.GetApplicationByIdQuery
{
    public class GetApplicationsByIdQueryHandler :
        IRequestHandler<GetApplicationByIdQuery, Domain.Models.Application>
    {
        private readonly IApplicationRepository _repo;

        public GetApplicationsByIdQueryHandler(IApplicationRepository repo)
            => _repo = repo;

        public async Task<Domain.Models.Application> Handle(
            GetApplicationByIdQuery request,
            CancellationToken cancellationToken)
            => await _repo.GetApplication(request.Id);
    }
}
