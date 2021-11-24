using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employers.Queries.GetEmployerByIdQuery
{
    public class GetEmployerByIdQueryHandler : IRequestHandler<GetEmployerByIdQuery, Employer>
    {
        private readonly IEmployerRepository _repo;

        public GetEmployerByIdQueryHandler(IEmployerRepository repo)
            => _repo = repo;

        public async Task<Employer> Handle(
            GetEmployerByIdQuery request,
            CancellationToken cancellationToken)
            => await _repo.GetEmployer(request.Id);
    }
}
