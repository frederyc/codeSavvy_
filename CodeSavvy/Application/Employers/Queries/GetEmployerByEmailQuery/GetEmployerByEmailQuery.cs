using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Employers.Queries.GetEmployerByEmailQuery
{
    public class GetEmployerByEmailQuery : IRequest<Employer>
    {
        public string Email { get; set; }
    }
}
