using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Jobs.Commands.DeleteJobCommand
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, Job>
    {
        private readonly IJobRepository _repo;

        public DeleteJobCommandHandler(IJobRepository repo)
            => _repo = repo;

        public async Task<Job> Handle(
            DeleteJobCommand request,
            CancellationToken cancellationToken)
            => await _repo.DeleteJob(request.Id);
    }
}
