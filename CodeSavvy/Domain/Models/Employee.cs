using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public Credentials Credentials { get; set; }

        [Required]
        [MaxLength(256)]
        public string FullName { get; set; }
        public Employee() { }
    }
}
