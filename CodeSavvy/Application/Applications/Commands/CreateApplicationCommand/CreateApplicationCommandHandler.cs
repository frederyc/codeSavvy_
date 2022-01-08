using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Applications.Commands.CreateApplicationCommand
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
        {
            var application = new Domain.Models.Application
            {
                Job = request.Job,
                Employee = request.Employee,
                Resume = request.Resume
            };
            return await _repo.CreateApplication(application);
        }

    }
}
