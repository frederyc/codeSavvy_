using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using MediatR;

namespace CodeSavvy.Application.Credentials.Commands.DeleteCredentialsCommand
{
    public class DeleteCredentialsCommandHandler : IRequestHandler<DeleteCredentialsCommand, Domain.Models.Credentials>
    {
        private readonly ICredentialsRepository _repo;

        public DeleteCredentialsCommandHandler(ICredentialsRepository repo)
            => _repo = repo;

        public async Task<Domain.Models.Credentials> Handle(
            DeleteCredentialsCommand request,
            CancellationToken cancellationToken)
            => await _repo.DeleteCredentials(request.Id);
    }
}
