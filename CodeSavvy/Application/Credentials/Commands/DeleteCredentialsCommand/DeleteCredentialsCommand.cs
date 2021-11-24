using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CodeSavvy.Application.Credentials.Commands.DeleteCredentialsCommand
{
    public class DeleteCredentialsCommand : IRequest<Domain.Models.Credentials>
    {
        public int Id { get; set; }
    }
}
