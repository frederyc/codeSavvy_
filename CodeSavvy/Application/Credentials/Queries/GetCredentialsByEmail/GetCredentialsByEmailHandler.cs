using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using MediatR;

namespace CodeSavvy.Application.Credentials.Queries.GetCredentialsByEmail
{
    public class GetCredentialsByEmailHandler :
        IRequestHandler<GetCredentialsByEmail, Domain.Models.Credentials>
    {
        private readonly ICredentialsRepository _repo;

        public GetCredentialsByEmailHandler(ICredentialsRepository repo)
            => _repo = repo;

        public async Task<Domain.Models.Credentials> Handle(
            GetCredentialsByEmail request,
            CancellationToken cancellationToken)
            => await _repo.GetCredentials(request.Email);

    }
}
