using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Jobs.Commands.UpdateJobCommand
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, Job>
    {
        private readonly IJobRepository _repo;

        public UpdateJobCommandHandler(IJobRepository repo)
            => _repo = repo;

        public async Task<Job> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new Job
            {
                Description = request.Description,
                Level = request.Level,
                Location = request.Location,
                Position = request.Position,
                PreferredQualifications = request.PreferredQualifications,
                MinimumQualifications = request.MinimumQualifications,
                Salary = request.Salary,
            };
            return await _repo.UpdateJob(request.Id, job);
        }
    }
}
