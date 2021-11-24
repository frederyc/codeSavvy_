using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSavvy.Domain.Models
{
    public class Employer
    {
        public int Id { get; set; }

        [Required]
        public Credentials Credentials { get; set; }

        [Required]
        [MaxLength(256)]
        public string CompanyName { get; set; }

        [Required]
        public string Image { get; set; } // Learn about blobs

        public Employer() 
        { 

        }
        
    }
}
