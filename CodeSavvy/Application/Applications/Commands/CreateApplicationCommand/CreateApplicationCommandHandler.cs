using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using MediatR;

namespace CodeSavvy.Application.Applications.CreateApplicationCommand
{
    public class CreateApplicationCommandHandler :
        IRequestHandler<CreateApplicationCommand, Domain.Models.Application>
    {
        private readonly IApplicationRepository _repo;

        public CreateApplicationCommandHandler(IApplicationRepository repo)
            => _repo = repo;

        public async Task<Domain.Models.Application> Handle(
            CreateApplicationCommand request,
            CancellationToken cancellationToken)
            => await _repo.CreateApplication(request.Application);
    }
}
