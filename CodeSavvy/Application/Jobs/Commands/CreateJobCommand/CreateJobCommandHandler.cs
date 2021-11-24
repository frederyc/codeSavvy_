using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Jobs.Commands.CreateJobCommand
{
    public class CreateJobCommandHandler : 
        IRequestHandler<CreateJobCommand, Job>
    {
        private readonly IJobRepository _repo;

        public CreateJobCommandHandler(IJobRepository repo)
            => _repo = repo;

        public async Task<Job> Handle(
            CreateJobCommand request,
            CancellationToken cancellationToken)
            => await _repo.CreateJob(request.Job);
    }
}
