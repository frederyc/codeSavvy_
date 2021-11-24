using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CodeSavvy.Application.Applications.CreateApplicationCommand
{
    public class CreateApplicationCommand : IRequest<Domain.Models.Application>
    {
        public Domain.Models.Application Application { get; set; }
    }
}
