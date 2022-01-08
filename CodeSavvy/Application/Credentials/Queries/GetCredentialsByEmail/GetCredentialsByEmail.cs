using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CodeSavvy.Application.Credentials.Queries.GetCredentialsByEmail
{
    public class GetCredentialsByEmail : IRequest<Domain.Models.Credentials>
    {
        public string Email { get; set; }
    }
}
