using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using MediatR;

namespace CodeSavvy.Application.Applications.Commands.DeleteApplicationCommand
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
