using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeSavvy.Domain.Enums;
using CodeSavvy.Domain.Models;
using MediatR;

namespace CodeSavvy.Application.Jobs.Commands.UpdateJobCommand
{
    public class UpdateJobCommand : IRequest<Job>
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public Position Position { get; set; }
        public Level Level { get; set; }
        public int Salary { get; set; }
        public string MinimumQualifications { get; set; }
        public string PreferredQualifications { get; set; }
        public string Description { get; set; }
    }
}
