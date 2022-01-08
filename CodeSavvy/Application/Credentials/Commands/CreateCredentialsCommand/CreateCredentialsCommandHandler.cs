using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using MediatR;

namespace CodeSavvy.Application.Credentials.Commands
{
    public class CreateCredentialsCommandHandler : 
        IRequestHandler<CreateCredentialsCommand, Domain.Models.Credentials>
    {
        private readonly ICredentialsRepository _repo;

        public CreateCredentialsCommandHandler(ICredentialsRepository repo)
            => _repo = repo;

        public async Task<Domain.Models.Credentials> Handle(
            CreateCredentialsCommand request,
            CancellationToken cancellationToken)
        {
            var credentials = new Domain.Models.Credentials
            {
                Email = request.Email,
                Password = request.Password
            };
            return await _repo.CreateCredentials(credentials);
        }
    }
}
