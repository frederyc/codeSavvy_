using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Applications.Queries.GetApplicationsForJobQuery
{
    public class GetApplicationsForJobQuery : IRequest<List<Domain.Models.Application>>
    {
        public Job Job { get; set; }
    }
}
