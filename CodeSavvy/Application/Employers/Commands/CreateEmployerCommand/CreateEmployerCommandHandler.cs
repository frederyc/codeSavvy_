using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeSavvy.Domain.Interfaces;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employers.Commands.CreateEmployerCommand
{
    public class CreateEmployerCommandHandler : 
        IRequestHandler<CreateEmployerCommand, Employer>
    {
        private readonly IEmployerRepository _repo;

        public CreateEmployerCommandHandler(IEmployerRepository repo)
            => _repo = repo;

        public async Task<Employer> Handle(
            CreateEmployerCommand request,
            CancellationToken cancellationToken)
        {
            var employer = new Employer
            {
                CompanyName = request.CompanyName,
                Image = request.Image,
                Credentials = request.Credentials
            };
            return await _repo.CreateEmployer(employer);
        }
    }
}
