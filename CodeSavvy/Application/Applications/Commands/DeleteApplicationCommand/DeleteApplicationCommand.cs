using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CodeSavvy.Domain.Models;

namespace CodeSavvy.Application.Applications.DeleteApplicationCommand
{
    public class DeleteApplicationCommand : IRequest<Domain.Models.Application>
    {
        public int Id { get; set; }
    }
}
