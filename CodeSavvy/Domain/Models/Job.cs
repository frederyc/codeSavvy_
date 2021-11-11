using CodeSavvy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Domain.Models
{
    public class Job
    {
        public int Id { get; set; }
        public Employer Employer { get; set; }
        public Location Location { get; set; }
        public Position Position { get; set; }
        public Level Level { get; set; }
        public int Salary { get; set; }

        public Job()
        {

        }
    }
}
