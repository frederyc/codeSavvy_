using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Applications.Queries.GetApplicationsForEmployeeQuery
{
    public class GetApplicationsForEmployeeQuery : IRequest<List<Domain.Models.Application>>
    {
        public int EmployeeId { get; set; }
    }
}
