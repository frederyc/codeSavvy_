using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CodeSavvy.Application.Applications.Queries.GetApplicationByIdQuery
{
    public class GetApplicationByIdQuery : IRequest<Domain.Models.Application>
    {
        public int Id { get; set; }
    }
}
