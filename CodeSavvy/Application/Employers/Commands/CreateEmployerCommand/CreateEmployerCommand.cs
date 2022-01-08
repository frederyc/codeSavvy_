using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employers.Commands.CreateEmployerCommand
{
    public class CreateEmployerCommand : IRequest<Employer>
    {
        public Domain.Models.Credentials Credentials { get; set; }
        public string CompanyName { get; set; }
        public string Image { get; set; } // Learn about blobs
    }
}
