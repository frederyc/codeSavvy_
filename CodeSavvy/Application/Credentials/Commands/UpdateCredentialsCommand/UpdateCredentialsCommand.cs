using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CodeSavvy.Application.Credentials.Commands.UpdateCredentialsCommand
{
    public class UpdateCredentialsCommand : IRequest<Domain.Models.Credentials>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
