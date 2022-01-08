using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employers.Queries.GetEmployerByEmailQuery
{
    public class GetEmployerByEmailQueryHandler : IRequestHandler<GetEmployerByEmailQuery, Employer>
    {
        private readonly IEmployerRepository _repo;

        public GetEmployerByEmailQueryHandler(IEmployerRepository repo)
        {
            _repo = repo;
        }


        public async Task<Employer> Handle(
            GetEmployerByEmailQuery request, 
            CancellationToken cancellationToken)
        {
            return await _repo.GetEmployer(request.Email);
        }
    }
}
