using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Applications.Commands.UpdateApplicationCommand
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
        {
            var application = new Domain.Models.Application
            {
                Id = request.Id,
                Resume = request.Resume
            };

            return await _repo.UpdateApplication(request.Id, application);
        }
    }
}
