using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using MediatR;

namespace CodeSavvy.Application.Applications.DeleteApplicationCommand
{
    public class DeleteApplicationCommandHandler :
        IRequestHandler<DeleteApplicationCommand, Domain.Models.Application>
    {
        private readonly IApplicationRepository _repo;

        public DeleteApplicationCommandHandler(IApplicationRepository repo)
            => _repo = repo;

        public async Task<Domain.Models.Application> Handle(
            DeleteApplicationCommand request,
            CancellationToken cancellationToken)
            => await _repo.DeleteApplication(request.Id);
    }
}
