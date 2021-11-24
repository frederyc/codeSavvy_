using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using MediatR;

namespace CodeSavvy.Application.Credentials.Queries.GetCredentialsById
{
    public class GetCredentialsByIdHandler : 
        IRequestHandler<GetCredentialsById, Domain.Models.Credentials>
    {
        private readonly ICredentialsRepository _repo;

        public GetCredentialsByIdHandler(ICredentialsRepository repo)
            => _repo = repo;

        public async Task<Domain.Models.Credentials> Handle(
            GetCredentialsById request,
            CancellationToken cancellationToken)
            => await _repo.GetCredentials(request.Id);
    }
}
