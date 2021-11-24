using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using MediatR;

namespace CodeSavvy.Application.Applications.UpdateApplicationCommand
{
    public class UpdateApplicationCommandHandler : 
        IRequestHandler<UpdateApplicationCommand, Domain.Models.Application>
    {
        private readonly IApplicationRepository _repo;

        public UpdateApplicationCommandHandler(IApplicationRepository repo)
            => _repo = repo;

        public async Task<Domain.Models.Application> Handle(
            UpdateApplicationCommand request,
            CancellationToken cancellationToken)
            => await _repo.UpdateApplication(request.Id, request.Application);
    }
}
