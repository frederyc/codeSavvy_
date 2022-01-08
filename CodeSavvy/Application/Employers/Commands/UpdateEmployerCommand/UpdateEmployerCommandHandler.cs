using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employers.Commands.UpdateEmployerCommand
{
    public class UpdateEmployerCommandHandler : IRequestHandler<UpdateEmployerCommand, Employer>
    {
        private readonly IEmployerRepository _repo;

        public UpdateEmployerCommandHandler(IEmployerRepository repo)
            => _repo = repo;

        public async Task<Employer> Handle(
            UpdateEmployerCommand request,
            CancellationToken cancellationToken)
        {
            var employer = new Employer
            {
                CompanyName = request.CompanyName,
                Image = request.Image
            };
            return await _repo.UpdateEmployer(request.Id, employer);
        }
    }
}
