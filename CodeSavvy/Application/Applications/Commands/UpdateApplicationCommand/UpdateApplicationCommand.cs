using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CodeSavvy.Application.Applications.UpdateApplicationCommand
{
    public class UpdateApplicationCommand : IRequest<Domain.Models.Application>
    {
        public int Id { get; set; }
        public Domain.Models.Application Application { get; set; }
    }
}
