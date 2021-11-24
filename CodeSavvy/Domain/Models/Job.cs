using CodeSavvy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Domain.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        public Employer Employer { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        public Level Level { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public string MinimumQualifications { get; set; }

        [Required]
        public string PreferredQualifications { get; set; }

        [Required]
        public string Description { get; set; }

        public Job()
        {

        }
    }
}
