using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employers.Commands.DeleteEmployerCommand
{
    public class DeleteEmployerCommandHandler : IRequestHandler<DeleteEmployerCommand, Employer>
    {
        private readonly IEmployerRepository _repo;

        public DeleteEmployerCommandHandler(IEmployerRepository repo)
            => _repo = repo;

        public async Task<Employer> Handle(
            DeleteEmployerCommand request,
            CancellationToken cancellationToken)
            => await _repo.DeleteEmployer(request.Id);
    }
}
